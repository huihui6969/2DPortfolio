using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyState
{
    ///<summary>���� ����</summary>
    Down,
    /// <summary>������ ��</summary>
    On,
    /// <summary>�� ����</summary>
    Up,
    /// <summary>������ ���� </summary>
    Not
}

public class ControllerManager : MonoBehaviour
{
    private static List<ControllerManager> Controllers = new List<ControllerManager>();

    //[SerializeField]
    //private string name;

    [SerializeField]
    private LinearInput[] Linears;

    [SerializeField]
    private ButtonInput[] Buttons;

    // Start is called before the first frame update
    void Start()
    {
        Controllers.Add(this);
    }

    public KeyState GetButton(int index)
    {
        if (index < 0 || index >= Buttons.Length) { return KeyState.Not; };

        if (Buttons[index].isDown)
        {
            return KeyState.Down;
        }
        else if (Buttons[index].isButton)
        {
            return KeyState.On;
        }
        else if (Buttons[index].isUp)
        {
            return KeyState.Up;
        }
        else
        {
            return KeyState.Not;
        };
    }

    public float GetLinear(int index)
    {
        if (index < 0 || index >= Linears.Length) { return 0; };

        return Linears[index].value;
    }

    public static ControllerManager GetController(int index)
    {
        if (index < 0 || index >= Controllers.Count) { return null; };

        return Controllers[index];
    }
}
