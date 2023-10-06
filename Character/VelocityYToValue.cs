using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityYToValue : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private ValueComponent target;

    void Update()
    {
        target.value = Mathf.Clamp(rigid.velocity.y, -1.0f, 1.0f);
    }
}
