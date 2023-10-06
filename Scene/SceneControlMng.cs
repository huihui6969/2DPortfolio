using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlMng : MonoBehaviour
{
    //씽글톤
    static SceneControlMng unique; //static 으로 선언해서 다른 스크립트에서 바로 사용 가능하게..

    public enum eLoaddingState //로딩바 현재진행
    {
        none            =0,
        start,
        ing,
        end
    }

    AsyncOperation loadProc; //로딩 구현을 위한 구조체 (LoadProcess)  
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

                //로딩바 계산
                //loadProc.progress
                return;
            }
            else
            {
                //로딩바를 제거
                //loadProc = null;
                nowLoadState = eLoaddingState.end;

            }
        }
    }

    public void StartTitle()
    {
        nowLoadState = eLoaddingState.start;
        loadProc = SceneManager.LoadSceneAsync("MainMenu");
        // 로딩바 생성
    }

    public void StartIngame()
    {
        loadProc = SceneManager.LoadSceneAsync("Pallet Town");
        // 로딩바 생성
    }

    public void StartDungeon()
    {
        loadProc = SceneManager.LoadSceneAsync("Dungeon");
        // 로딩바 생성
    }
}
    