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
        // ���Ժ��� ����� �����Ͱ� �����ϴ��� �Ǵ�.
        for (int i = 0; i < 3; i++)
        {
            if(File.Exists(DataManager.Instance.path + $"{i}")) //������
            {
                saveFile[i] = true; //������ ���� ���� �Ǵ�
                DataManager.Instance.nowSlot = i; //������ ������
                DataManager.Instance.LoadData();

                slotText[i].text = DataManager.Instance.nowPlayer.name + ", " + DateTime.Now.ToString(); //�� �ڿ� �ð��� ǥ�ð���
            }
            else //�������
            {
                slotText[i].text = "�������";
            }
        }
        DataManager.Instance.DataClear(); //�ҷ��� ���� ����
    }

    public void Slot(int number)
    {
        DataManager.Instance.nowSlot = number;

        // 1. ����� �����Ͱ� ������ -> �ҷ������ؼ� ���Ӿ����� �Ѿ��
        if (saveFile[number])
        {
            DataManager.Instance.LoadData();
            GameSceneLoad();
        }
        else // 2. ����� �����Ͱ� ������
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
        if(!saveFile[DataManager.Instance.nowSlot]) //����Ȱ� ���ٸ�
        {
            DataManager.Instance.nowPlayer.name = newPlayerName.text; //������
            DataManager.Instance.SaveData(); //�ѹ� �� ����
        }

        SceneManager.LoadScene(2);
    }
}
