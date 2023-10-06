using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioManager music;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            music.PlayMusic("Boss");
            gameObject.SetActive(false);
            AudioManager.instance.PlaySFX("BossSpawn");
        }
    }
}
