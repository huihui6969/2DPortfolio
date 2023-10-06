using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWalking : CheckComponent
{
    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private MoveByValue isMove;

    void Update()
    {
        if (Mathf.Abs(isMove.value) > 0.1f)
        {
            result = true;
        }
        else
        {
            result = false;
        };
    }
}
