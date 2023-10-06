using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckJumping : CheckComponent
{
    [SerializeField]
    private Rigidbody2D rigid;

    void Update()
    {
        if (Mathf.Abs(rigid.velocity.y) < 0.01f)
        {
            result = false;
        }
        else
        {
            result = true;
        };
    }
}
