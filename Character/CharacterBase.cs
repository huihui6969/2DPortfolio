using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField]
    private ResourceContainer health;

    [SerializeField]
    private SpriteRenderer render;

    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private Animator anim;

    private void Awake()
    {
    }
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

    }

    void Update()
    {
    }

    public void GetDamage(int amount, Vector2 targetPos)
    {
        if (health != null)
        {
            if (health.currentValue <= 0)
            {
                return;
            }

            health.currentValue -= amount;

            if (health.currentValue <= 0)
            {
                IsDie();
                //Rigidbody2D rigid = GetComponent<Rigidbody2D>();
                //if (rigid != null) { Destroy(rigid); };

                //Collider2D col = GetComponent<Collider2D>();
                //if (col != null) { Destroy(col); };

            }

            if (anim != null && amount > 0)
            {
                if (health.currentValue <= 0)
                {
                    render.color = new Color(1, 0, 0, 0.8f);

                    Invoke("OffDamaged", 0.5f);

                    StartCoroutine(AnimatedDie());
                    Debug.Log("죽어요...");
                }
                else
                {
                    //                      (R ,G ,B ,투명도)
                    render.color = new Color(1, 0, 0, 0.8f);

                    int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;

                    rigid.AddForce(new Vector2(dirc, 1) * 5, ForceMode2D.Impulse);

                    Invoke("OffDamaged", 0.5f);

                    Debug.Log("10데미지 입음");    

                }
            }
            //맞으면 멈출거에요!!
            //walkDisableTime = Mathf.Max(0.5f, walkDisableTime);

            //anim.SetTrigger("TriggerHit");

            // 맞았을때 이펙트 사용
            //if (hitEffect != null)
            //{
            //    GameObject currentEffect = Instantiate(hitEffect);

            //    if (boneTransform != null)
            //    {
            //        currentEffect.transform.position = boneTransform.position;
            //    }

            //    else
            //    {
            //        currentEffect.transform.position = transform.position;
            //    }
            //}

        }
    }
    IEnumerator AnimatedDie()
    {
        anim.SetTrigger("TriggerDie");

        yield return new WaitForSeconds(2.0f);

        Destroy(gameObject);

        //죽었을때 이펙트 사용
        //if (prefab != null)
        //{
        //    GameObject result = Instantiate(prefab);
        //    result.transform.position = location;
        //    if (islocalPosition)
        //    {
        //        result.transform.position += transform.position;
        //    };
        //}


    }

    private void OffDamaged()   
    {
        //layer를 통한 무적판정 만들어보기!
        render.color = new Color(1, 1, 1, 1f);
    }
}
