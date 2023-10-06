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
                // transform.right�� �������� �ǹ���
                // Vector2.left�� (-1, 0) �� �������� ������ �������� �ٲ��شٴ� �����.
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
