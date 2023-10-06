using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSecend : MonoBehaviour
{
    [SerializeField]
    private float secend;
    private void Update()
    {
        Invoke("DestroyEffect", secend);
    }


    private void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
