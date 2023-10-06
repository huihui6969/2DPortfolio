using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByTrigger : MonoBehaviour
{
    public string targetTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {

            Destroy(gameObject);
        };
    }
}
