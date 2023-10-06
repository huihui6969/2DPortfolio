using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionSceneByButton : MonoBehaviour
{
    private GameObject sceneGate;

    [SerializeField]
    private FadeEffect anim;

    private bool isLoading = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isLoading)
        {
            if (sceneGate != null)
            {
                Invoke("LoadNextScene", 1.0f);
                anim.NextLevel();
            }
        }
    }

    private void LoadNextScene()
    {
        SceneControlMng.instance.StartDungeon();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SceneGate"))
        {
            sceneGate = collision.gameObject;
            isLoading = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == sceneGate)
            {
                sceneGate = null;
                isLoading = false;
            }
        }
    }
}
