using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1.2f);
        anim.SetTrigger("Start");
    }
}
