using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreToText : MonoBehaviour
{
    [SerializeField]
    private Text target;

    void Update()
    {
        target.text =  Score.GetContainer.value.ToString();
    }
}
