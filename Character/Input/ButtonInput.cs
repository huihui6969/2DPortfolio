using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum WantTarget
//{
//    target1,
//    target2
//}

public class ButtonInput : MonoBehaviour
{
    public bool isDown = false;
    public bool isButton = false;
    public bool isUp = false;

    //[SerializeField]
    //private WantTarget wantTarget;
   // private KeyCode realTarget;

    [SerializeField]
    private KeyCode target = KeyCode.LeftAlt;

    //[SerializeField]
    //public KeyCode target2 = KeyCode.LeftControl;
    void Update()
    {
        //if(Input.GetKey(KeyCode.Space))
        //{
        //    realTarget = target1;
        //}

        //if (Input.GetKey(KeyCode.LeftControl))
        //{
        //    realTarget = target2;
        //}

        isDown = Input.GetKeyDown(target);
        isButton = Input.GetKey(target);
        isUp = Input.GetKeyUp(target);
    }
}
