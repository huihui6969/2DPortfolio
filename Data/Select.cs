using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    public GameObject create;
    public Text[] slotText;
    public Text newPlayerName;

    bool[] saveFile = new bool[3]; 
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if(File.Exists(DataManager.instance.path + $"{i}"))
            {
                saveFile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.nowPlayer.name;
            }
            else
            {
                slotText[i].text = "Empty";
            }
        }
        DataManager.instance.DataClear();
    }
    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;

        if (saveFile[number])
        {
            DataManager.instance.LoadData();
            StartGame();
        }
        else
        {
            Create();
        }

    }

    public void Create()
    {
        create.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        if(!saveFile[DataManager.instance.nowSlot])
        {
            DataManager.instance.nowPlayer.name = newPlayerName.text;
            DataManager.instance.SaveData();
        }
        SceneControlMng.instance.StartIngame();
    }
}
