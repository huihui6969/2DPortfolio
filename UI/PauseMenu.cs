using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuPanel;

    [SerializeField]
    private GameObject settingUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenSettingUI()
    {
        settingUI.gameObject.SetActive(true);
    }

    public void CloseSettingUI()
    {
        settingUI.gameObject.SetActive(false);
    }
}
