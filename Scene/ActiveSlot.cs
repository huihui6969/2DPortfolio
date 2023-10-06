using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSlot : MonoBehaviour
{
    public GameObject create;
    public void Create()
    {
        create.gameObject.SetActive(true);
    }
}
