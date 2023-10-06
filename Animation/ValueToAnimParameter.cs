using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueToAnimParameter : ValueComponent
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private string parameter;

    [SerializeField]
    public bool isAbsolute = true;

    void Update()
    {
        if (isAbsolute) //{ value = Mathf.Abs(value); };
        {
            anim.SetFloat(parameter, value);
        }   
    }
}
