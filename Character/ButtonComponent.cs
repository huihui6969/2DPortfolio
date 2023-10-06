using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonComponent : MonoBehaviour
{
    [SerializeField]
    protected bool value = false;

    [SerializeField]
    private KeyState ActivateCondition;

    public void SetButton(KeyState currentKey)
    {
        if (currentKey == ActivateCondition)
        {
            value = true;
        };
    }
}
