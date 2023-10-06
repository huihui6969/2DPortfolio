using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpByButton : ButtonComponent
{
    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private AttackByButton isAttacking;
    void Update()
    {
        if (isAttacking.attacking == false)
        {
            if (value)
            {
                rigid.AddForce(Vector2.up * jumpForce);
                AudioManager.instance.PlaySFX("PlayerJumpUp");
                value = false;
            };
        }
        
    }
}
