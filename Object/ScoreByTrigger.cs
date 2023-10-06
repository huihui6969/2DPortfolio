using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreByTrigger : MonoBehaviour
{
    [SerializeField]
    private int scoreValue;

    public string targetTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            AudioManager.instance.PlaySFX("CoinDropSound");
            Score.GetContainer.value += scoreValue;
        };
    }
}
