using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlMng : MonoBehaviour
{
    //�ű���
    static SceneControlMng unique; //static ���� �����ؼ� �ٸ� ��ũ��Ʈ���� �ٷ� ��� �����ϰ�..

    public enum eLoaddingState //�ε��� ��������
    {
        none            =0,
        start,
        ing,
        end
    }

    AsyncOperation loadProc; //�ε� ������ ���� ����ü (LoadProcess)  
    eLoaddingState nowLoadState = eLoaddingState.none;

    static public SceneControlMng instance
    {
        get { return unique; }
    }

    private void Awake()
    {
        unique = this;
        DontDestroyOnLoad(gameObject);
        StartTitle();
    }

    private void LateUpdate()
    {
        if(loadProc != null)
        {
            if(!loadProc.isDone)
            {
                nowLoadState = eLoaddingState.ing;

                //�ε��� ���
                //loadProc.progress
                return;
            }
            else
            {
                //�ε��ٸ� ����
                //loadProc = null;
                nowLoadState = eLoaddingState.end;

            }
        }
    }

    public void StartTitle()
    {
        nowLoadState = eLoaddingState.start;
        loadProc = SceneManager.LoadSceneAsync("MainMenu");
        // �ε��� ����
    }

    public void StartIngame()
    {
        loadProc = SceneManager.LoadSceneAsync("Pallet Town");
        // �ε��� ����
    }

    public void StartDungeon()
    {
        loadProc = SceneManager.LoadSceneAsync("Dungeon");
        // �ε��� ����
    }
}
    