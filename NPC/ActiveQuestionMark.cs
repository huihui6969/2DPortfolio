using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveQuestionMark : MonoBehaviour
{

    [SerializeField]
    private Transform noticedTarget;

    [SerializeField]
    private GameObject questionMark;

    [SerializeField]
    private GameObject dialogueUI;

    [SerializeField]
    private GameObject skill;
    public bool playerIsClose = false;

    void Start()
    {
        questionMark.SetActive(playerIsClose);
        dialogueUI.SetActive(playerIsClose);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(noticedTarget.position, transform.position) < 1.5f)
        {
            playerIsClose = true;
        }    
        else
        {
            playerIsClose = false;
        }

        questionMark.SetActive(playerIsClose);
        dialogueUI.SetActive(playerIsClose);

        if(Input.GetKeyDown(KeyCode.E) && playerIsClose == true)
        {
            skill.SetActive(true);
            AudioManager.instance.PlaySFX("NPCSound");

        }
        else if(playerIsClose == false)
        {
            skill.SetActive(false);
        }
    }
}
