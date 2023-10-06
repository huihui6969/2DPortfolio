using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ValuePagackager
{
    public ValueComponent[] components;
}

[System.Serializable]
public class ButtonPagackager
{
    public ButtonComponent[] components;
}

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private ControllerManager controller;

    [SerializeField]
    private ValuePagackager[] values;

    [SerializeField]
    private ButtonPagackager[] buttons;

    [SerializeField]
    public bool[] buttonAvailable;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < values.Length; i++)
        {
            for (int j = 0; j < values[i].components.Length; j++)
            {
                if (values[i].components[j] != null)
                {
                    values[i].components[j].value = controller.GetLinear(i);
                };
            };
        };

        for (int i = 0; i < buttons.Length; i++)
        {
            for (int j = 0; j < buttons[i].components.Length; j++)
            {
                if (buttons[i].components[j] != null && buttonAvailable[i])
                {
                    buttons[i].components[j].SetButton(controller.GetButton(i));
                };
            };
        };
    }
}
