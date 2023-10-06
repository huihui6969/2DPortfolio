using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : CheckComponent
{
    [SerializeField]
    private Rigidbody2D rigid;

    void Update()
    {
        if (Mathf.Abs(rigid.velocity.y) < 0.01f)
        {
            result = true;
        }
        else
        {
            result = false;
        };
    }
}
