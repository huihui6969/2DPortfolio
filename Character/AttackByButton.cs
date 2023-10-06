using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// case ������ ���� ���⿡ ���� �ݸ��� ��ġ �޾ƿ���

public class AttackByButton : ButtonComponent
{
    [SerializeField]
    private Animator anim;

    //[SerializeField]
    //private WantTarget wantTarget;

    [SerializeField]
    private string[] target;

    //[SerializeField]
    //private CharacterBase effect; 

    [SerializeField]
    private CheckGround checker;

    [SerializeField]
    private GameObject attackArea = default;

    public bool attacking = false;

    [SerializeField]
    private float attackTiming;

    [SerializeField]
    private float timeToStopFlip; // �����߿��� ���� �� �ٲٰ� �ϴ½ð�

    //[SerializeField]
    //private float timeToActivateArea; // ���� ��Ʈ�ڽ� Ȱ��ȭ �ð�


    private float timer = 0f;

    [SerializeField]
    private float attackCoolDownCurrent;

    [SerializeField]
    private float attackCoolDown;

    private void Start()
    {
        attackArea.SetActive(attacking);
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) && checker.result) // �Ϲ� ����
        {

            if (attackCoolDownCurrent < Time.realtimeSinceStartup)
            {
                Invoke("Attack", attackTiming);
                AttackAnimation();
                attackCoolDownCurrent = Time.realtimeSinceStartup + attackCoolDown;
            }
            //effect.InstantiateEffect();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && checker.result == false) //���� ����
        {

            if (attackCoolDownCurrent < Time.realtimeSinceStartup)
            {
                Invoke("Attack", attackTiming);
                anim.SetTrigger(target[3]);
                AudioManager.instance.PlaySFX("PlayerAttack03");
                attackCoolDownCurrent = Time.realtimeSinceStartup + attackCoolDown;
            }
            //effect.InstantiateEffect();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToStopFlip)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(false);
            }
        }
        CastSkill();
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }

    private void AttackAnimation()
    {
        float randomAttack = Random.Range(0.0f, 1.0f);

        if (randomAttack <= 0.4f)
        {
            anim.SetTrigger(target[0]);
            AudioManager.instance.PlaySFX("PlayerAttack01");
        }

        else if (randomAttack > 0.4 && randomAttack <= 0.7f)
        {
            anim.SetTrigger(target[1]);
            AudioManager.instance.PlaySFX("PlayerAttack02");
        }

        else
        {
            anim.SetTrigger(target[2]);
            AudioManager.instance.PlaySFX("PlayerAttack03");
        }
    }

    private void CastSkill()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
            anim.SetTrigger(target[4]);
            attackCoolDownCurrent = Time.realtimeSinceStartup + attackCoolDown;
        }
    }
}
