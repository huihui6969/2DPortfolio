using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AIBase : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private SpriteRenderer render;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float monsterSpeed;

    [SerializeField]
    private float monsterLimit;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float monsterDistance;

    [SerializeField]
    private float attackCoolDown;
    private float attackCoolDownCurrent;

    [SerializeField]
    private float attackFreezedTime; //공격시 멈추는 시간

    [SerializeField]
    private float attackCastTime; //공격시전타이밍

    [SerializeField]
    public Transform noticedTarget;

    [SerializeField]
    private GameObject monsterAttackArea; //히트박스

    [SerializeField]
    private ResourceContainer health;

    [SerializeField]
    private float timeToAttack; //히트박스 활성화 시간
    private float timer;

    [HideInInspector]
    public bool attacking = false;

    private Vector3 location;
    private bool islocalPosition;

    private bool enableAct1;
    private bool enableAct2;

    [SerializeField]
    private Transform startPoint; // 플라잉몹 스폰지역

    [SerializeField]
    private Transform effectLocation; // 이펙트 시전 위치

    [SerializeField]
    private GameObject[] skillEffect; // 이펙트

    ResourceContainer GetHealthContainer()
    {
        return health;
    }
    public bool IsDie()
    {
        if (health != null && health.currentValue <= 0)
        {
            return true;
        }
        return false;

    }
    void Start()
    {
        enableAct1 = true;
        enableAct2 = true;
        monsterAttackArea.SetActive(attacking);
        //enableAct1 = false;
        //enableAct2 = true;
        //objWeapon = privotWeaponR.GetChild(0).gameObject;
        //colliderWeapon = objWeapon.GetComponent<BoxCollider>();
        //colliderWeapon.enabled = false;
    }
    void Update()
    {
        if (enableAct1 == true && enableAct2 == true)
        {
            MonsterAttack();
            MonsterMove();
        }
    }
    private void MonsterMove()
    {
        if (gameObject.layer == 9) // layer 9는 플라잉 몬스터 구현임
        {

            if (Vector3.Distance(noticedTarget.position, transform.position) < 6 &&
               Vector3.Distance(noticedTarget.position, transform.position) > 0.5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, noticedTarget.position, monsterSpeed * Time.deltaTime);
                anim.SetBool("IsFly", true);

                Vector2 direction = noticedTarget.position - transform.position;

                if (direction.x < 0)
                {
                    transform.right = Vector2.right;
                }
                else
                {
                    transform.right = Vector2.left;

                }

            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, startPoint.position, monsterSpeed * Time.deltaTime);

                //anim.SetBool("IsWalk", false);

                Vector2 direction = startPoint.position - transform.position;

                if (direction.x < 0)
                {
                    transform.right = Vector2.right;
                }
                else
                {
                    transform.right = Vector2.left;
                }
            }
        }
        else if(gameObject.layer == 7 || gameObject.layer == 10)
        {
            if (Vector3.Distance(noticedTarget.position, transform.position) < 10 &&
                Vector3.Distance(noticedTarget.position, transform.position) > 2)
            {
                Vector2 direction = noticedTarget.position - transform.position;

                anim.SetBool("IsWalk", true);

                bool controllable = true;

                if (Mathf.Abs(rigid.velocity.x) > monsterSpeed) controllable = false;

                if (direction.x < 0 && controllable)
                {
                    transform.right = Vector2.right;
                    rigid.AddForce(Vector2.left * monsterSpeed);
                    rigid.velocity = new Vector2(Mathf.Clamp(rigid.velocity.x, -monsterLimit, monsterLimit), rigid.velocity.y);
                }
                else if (direction.x > 0 && controllable)
                {
                    transform.right = Vector2.left;
                    rigid.AddForce(Vector2.right * monsterSpeed);
                    rigid.velocity = new Vector2(Mathf.Clamp(rigid.velocity.x, -monsterLimit, monsterLimit), rigid.velocity.y);
                }
                else
                {
                    if (rigid.velocity.x < -monsterSpeed)
                    {
                        rigid.velocity = new Vector2(rigid.velocity.x + (monsterSpeed / 2), rigid.velocity.y);
                    }
                    else if (rigid.velocity.x < monsterSpeed)
                    {
                        rigid.velocity = new Vector2(rigid.velocity.x - (monsterSpeed / 2), rigid.velocity.y);
                    }
                    else
                    {
                        rigid.velocity = new Vector2(rigid.velocity.x * 0.95f, rigid.velocity.y);
                    };
                };
            }

            else
            {
                anim.SetBool("IsWalk", false);
            }
        }

        else
        {
            if (Vector3.Distance(noticedTarget.position, transform.position) < 18 &&
                Vector3.Distance(noticedTarget.position, transform.position) > 3)
            {
                Vector2 direction = noticedTarget.position - transform.position;

                anim.SetBool("IsWalk", true);

                bool controllable = true;

                if (Mathf.Abs(rigid.velocity.x) > monsterSpeed) controllable = false;

                if (direction.x < 0 && controllable)
                {
                    transform.right = Vector2.right;
                    rigid.AddForce(Vector2.left * monsterSpeed);
                    rigid.velocity = new Vector2(Mathf.Clamp(rigid.velocity.x, -monsterLimit, monsterLimit), rigid.velocity.y);
                }
                else if (direction.x > 0 && controllable)
                {
                    transform.right = Vector2.left;
                    rigid.AddForce(Vector2.right * monsterSpeed);
                    rigid.velocity = new Vector2(Mathf.Clamp(rigid.velocity.x, -monsterLimit, monsterLimit), rigid.velocity.y);
                }
                else
                {
                    if (rigid.velocity.x < -monsterSpeed)
                    {
                        rigid.velocity = new Vector2(rigid.velocity.x + (monsterSpeed / 2), rigid.velocity.y);
                    }
                    else if (rigid.velocity.x < monsterSpeed)
                    {
                        rigid.velocity = new Vector2(rigid.velocity.x - (monsterSpeed / 2), rigid.velocity.y);
                    }
                    else
                    {
                        rigid.velocity = new Vector2(rigid.velocity.x * 0.95f, rigid.velocity.y);
                    };
                };
            }

            else
            {
                anim.SetBool("IsWalk", false);
            }
        }

    }
    public void MonsterAttack() // AI 공격 구현(데미지 처리 미포함)
    {
        if (gameObject.layer == 9)
        {
            monsterDistance = 1.0f;
        }
        else if(gameObject.layer == 7 || gameObject.layer == 10)
        {
            monsterDistance = 2.0f;
        }
        else
        {
            monsterDistance = 3.0f;
        }

        if (Vector3.Distance(noticedTarget.position, transform.position) < monsterDistance && IsDie() == false)
        {
            if (attackCoolDownCurrent <= Time.realtimeSinceStartup)
            {
                attackCoolDownCurrent = Time.realtimeSinceStartup + attackCoolDown;

                if (gameObject.layer == 8) //보스일 때
                {
                    float randomAction = Random.Range(0.0f, 1.0f);

                    if (randomAction <= 0.65f)
                    {
                        anim.SetTrigger("TriggerAttack01");
                        Invoke("UnFreezeMonster", attackFreezedTime);
                        Invoke("Attack", attackCastTime);
                    }

                    else if (randomAction > 0.65f && randomAction <= 0.99f)
                    {
                        anim.SetTrigger("TriggerAttack02");
                        Invoke("UnFreezeMonster", attackFreezedTime);
                        Invoke("Attack", attackCastTime);
                    }

                    else
                    {
                        anim.SetTrigger("TriggerAttack03");
                        Invoke("UnFreezeMonster", attackFreezedTime);
                        Invoke("Attack", attackCastTime);
                    }
                }

                else //보스가 아닐 때
                {
                    anim.SetTrigger("TriggerAttack01");
                    Invoke("UnFreezeMonster", attackFreezedTime);
                    Invoke("Attack", attackCastTime);
                }

                enableAct1 = false;
            }
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack) // 히트박스 활성화 시간
            {
                timer = 0;
                attacking = false;
                monsterAttackArea.SetActive(false);
            }
        }
    }
    private void Attack()
    {
        attacking = true;
        monsterAttackArea.SetActive(attacking);
    }
    public void GetDamage(int amount, Vector2 targetPos) // AI 받는 데미지 구현
    {
        if (health != null)
        {
            if (health.currentValue <= 0)
            {
                //Stage();
                //stageStep += 1;
                return;
            }

            health.currentValue -= amount;
            AudioManager.instance.PlaySFX("HitSound");

            if (health.currentValue <= 0)
            {
                IsDie();

                UnityEngine.AI.NavMeshAgent nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

                if (nav != null)
                {
                    nav.enabled = false;
                }
                AIBase ai = GetComponent<AIBase>();
                if (ai != null)
                {
                    ai.enabled = false;
                }
            }

            if (anim != null && amount > 0)
            {
                //죽었을때
                if (health.currentValue <= 0)
                {
                    CreateEffect();
                    StartCoroutine(AnimatedDie());
                }
                else
                {
                    render.color = Color.red;
                    Invoke("OffDamaged", 0.5f);
                    Debug.Log("10데미지 입음");
                    CreateEffect();
                }
            }

        }
    }
    IEnumerator AnimatedDie()
    {
        anim.SetTrigger("TriggerDie");

        yield return new WaitForSeconds(2.0f);

        Destroy(gameObject);

        if (prefab != null) //코인 생성
        {
            islocalPosition = true;

            GameObject result = Instantiate(prefab);
            result.transform.position = location;

            if (islocalPosition)
            {
                result.transform.position += transform.position;
            };
        }
    } // AI 사망 함수
    private void OffDamaged()
    {
        //layer를 통한 무적판정 만들어보기!
        render.color = new Color(1, 1, 1, 1f);
    } // 공격 받았을 때!
    public void FreezeMonster()
    {
        enableAct1 = false;
    }
    public void UnFreezeMonster()
    {
        enableAct1 = true;
    }
    public void CreateEffect()
    {
        int number = 0;
        float randomEffect = Random.Range(0.0f, 1.0f);

        if (randomEffect <= 0.2f)
        {
            number = 0;
        }

        else
        {
            number = 1;
        }

        GameObject currentEffect = Instantiate(skillEffect[number]);

        Vector2 direction = noticedTarget.position - transform.position;

        if (direction.x < 0 && effectLocation != null)
        {
            currentEffect.transform.right = Vector2.right;
        }

        else if (direction.x > 0 && effectLocation != null)
        {
            currentEffect.transform.right = Vector2.left;
        }

        currentEffect.transform.position = effectLocation.position;
    }
}




//private void Patrol()
//{
//    if ((transform.position - noticedTarget.position).magnitude > distance)
//    {
//        agent.speed = 3;

//        if (patrolLeftTime <= 0)
//        {
//            Vector3 GoalLocation = patrolCenter;

//            GoalLocation.x += Random.Range(-patrolRange, patrolRange);
//            GoalLocation.z += Random.Range(-patrolRange, patrolRange);
//            GoalLocation.y = 0;

//            agent.SetDestination(GoalLocation);

//            patrolLeftTime = patrolTime;
//        }
//        else
//        {
//            patrolLeftTime -= Time.deltaTime;
//        }
//    }
//    else
//    {
//        agent.speed = 3;
//        agent.SetDestination(noticedTarget.position);
//    }
//}

