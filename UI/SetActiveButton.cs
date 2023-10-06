using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveButton : MonoBehaviour
{
    public GameObject create;
    public void OpenButton()
    {
        create.gameObject.SetActive(true);
    }

    public void CloseButton()
    {
        create.gameObject.SetActive(false);
    }
}
