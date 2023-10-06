using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckToAnimParameter : MonoBehaviour
{
    [SerializeField]
    private CheckComponent checker;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private string target;

    void Update()
    {
        anim.SetBool(target, checker.result);
    }
}
