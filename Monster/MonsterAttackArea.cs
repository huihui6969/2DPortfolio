using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MonsterAttackArea : MonoBehaviour
{
    [SerializeField]
    private string target;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(target))
        {
            collider.GetComponent<CharacterBase>().GetDamage(10, transform.position);
        }
    }
}
