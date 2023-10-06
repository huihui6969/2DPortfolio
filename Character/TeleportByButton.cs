using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportByButton : MonoBehaviour
{
    private GameObject currentTelepoter;

    [SerializeField]
    private FadeEffect anim;

    private bool isTeleport = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isTeleport)
        {
            AudioManager.instance.PlaySFX("TeleportSound");
            Invoke("Teleport", 0.7f);
            anim.NextLevel();
        }
    }

    private void Teleport()
    {
        if (currentTelepoter != null)
        {
            transform.position = currentTelepoter.GetComponent<Teleporter>().GetDestination().position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleporter"))
        {
            currentTelepoter = collision.gameObject;
            isTeleport = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleporter"))
        {
            if(collision.gameObject == currentTelepoter)
            {
                currentTelepoter = null;
                isTeleport = false;
            }
        }
    }
}
