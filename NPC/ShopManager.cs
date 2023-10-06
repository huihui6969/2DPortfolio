using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[6, 6];

    void Start()
    {

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;

        //Price's
        shopItems[2, 1] = 50;
        shopItems[2, 2] = 70;
        shopItems[2, 3] = 100;
        shopItems[2, 4] = 500;
        shopItems[2, 5] = 700;

        ////Quantity's 구매 수량은 다시 생각 ㄱㄱ
        //shopItems[3, 1] = 0;
        //shopItems[3, 2] = 0;
        //shopItems[3, 3] = 0;
        //shopItems[3, 4] = 0;
        //shopItems[3, 5] = 0;
    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(Score.GetContainer.value >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            Score.GetContainer.value -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            //shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++; 수량 추가
            //ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }
}
