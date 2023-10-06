using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractByTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject door;

    [SerializeField]
    private float openSpeed;

    [SerializeField]
    private Transform targetPosition;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            door.transform.position = Vector2.MoveTowards(door.transform.position, targetPosition.position, openSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX("OpenDoorSound");
        }
    }
}
