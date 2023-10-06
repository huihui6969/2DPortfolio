using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameData : MonoBehaviour
{
    public Text name;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (DataManager.instance.nowPlayer.coin != null && DataManager.instance.nowPlayer.name != null)
        {
            Invoke("initiallizeData", 0.01f);
            Debug.Log("Ãâ·ÂµÊ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DataManager.instance.nowPlayer.coin = Score.GetContainer.value;
            Debug.Log(DataManager.instance.nowPlayer.coin);
            Save();
        }
    }

    public void initiallizeData()
    {
        Score.GetContainer.value += DataManager.instance.nowPlayer.coin;
        name.text = DataManager.instance.nowPlayer.name;
    }
    public void Save()
    {
        DataManager.instance.SaveData();
        Debug.Log("saving");
    }
}
