using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class Menu : MonoBehaviour
{
    public GameObject creat;
    public Text[] slotText;
    public Text newPlayerName;

    bool[] saveFile = new bool[3];

    void Start()
    {
        // 슬롯별로 저장된 데이터가 존재하는지 판단.
        for (int i = 0; i < 3; i++)
        {
            if(File.Exists(DataManager.Instance.path + $"{i}")) //존재함
            {
                saveFile[i] = true; //데이터 존재 유무 판단
                DataManager.Instance.nowSlot = i; //슬롯을 가져옴
                DataManager.Instance.LoadData();

                slotText[i].text = DataManager.Instance.nowPlayer.name + ", " + DateTime.Now.ToString(); //이 뒤에 시간도 표시가능
            }
            else //존재안함
            {
                slotText[i].text = "비어있음";
            }
        }
        DataManager.Instance.DataClear(); //불러온 값들 리셋
    }

    public void Slot(int number)
    {
        DataManager.Instance.nowSlot = number;

        // 1. 저장된 데이터가 있을때 -> 불러오기해서 게임씬으로 넘어가기
        if (saveFile[number])
        {
            DataManager.Instance.LoadData();
            GameSceneLoad();
        }
        else // 2. 저장된 데이터가 없을때
        {
            SaveWindow();
        }
    }

    public void SaveWindow()
    {
        creat.gameObject.SetActive(true);
    }

    public void GameSceneLoad()
    {
        if(!saveFile[DataManager.Instance.nowSlot]) //저장된게 없다면
        {
            DataManager.Instance.nowPlayer.name = newPlayerName.text; //덧씌움
            DataManager.Instance.SaveData(); //한번 더 저장
        }

        SceneManager.LoadScene(2);
    }
}
