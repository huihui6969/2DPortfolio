using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackArea : MonoBehaviour
{
    [SerializeField]
    private string target;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(target))
        {
            collider.GetComponent<AIBase>().GetDamage(10, transform.position);
        }
    }
}
