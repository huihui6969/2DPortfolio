using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //SceneControlMng mngScene;

    private void Start()
    {
        //GameObject go = GameObject.Find("SceneControlManager");
        //mngScene = go.GetComponent<SceneControlMng>();
    }
    public void PlayGame()
    {
        SceneControlMng.instance.StartIngame();
    }
}
