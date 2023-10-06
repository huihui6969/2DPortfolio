using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FlipByValue : ValueComponent
{
    [SerializeField]
    private SpriteRenderer render;

    [SerializeField]
    private AttackByButton isAttack;

    [SerializeField]
    private CharacterBase character;
    void Update()
    {
        if(isAttack.attacking == false && character.IsDie() == false)
        {
            if (value < 0)
            {
                // transform.right는 빨간축을 의미함
                // Vector2.left는 (-1, 0) 즉 빨간축의 방향을 왼쪽으로 바꿔준다는 얘기임.
                transform.right = Vector2.left;
                //render.flipX = true;
            }
            else if (value > 0)
            {
                transform.right = Vector2.right;
                //render.flipX = false;
            };
        }
       
    }
}
