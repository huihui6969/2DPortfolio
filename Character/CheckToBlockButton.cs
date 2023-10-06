using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckToBlockButton : MonoBehaviour
{
    [SerializeField]
    private CheckComponent checker;

    [SerializeField]
    private CharacterManager manager;

    [SerializeField]
    private int buttonNumber;

    void Update()
    {
        manager.buttonAvailable[buttonNumber] = checker.result;
    }
}
