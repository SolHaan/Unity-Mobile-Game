using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//�����ϴ� ���
// 1. ������ �����Ͱ� ����
// 2. �����͸� ���̽����� ��ȯ
// 3. ���̽��� �ܺο� ����

//�ҷ����� ���
// 1. �ܺο� ����� ���̽��� ������
// 2. ���̽��� ���������·� ��ȯ
// 3. �ҷ��� �����͸� ���

public class PlayerData
{
    // �̸�, ����, ����, �������� ����
    public string name;
    public int level;
    public int coin;
    public int item;
}

public class DataManager : Singleton<DataManager>
{
    public PlayerData nowPlayer = new PlayerData();

    public string path;
    public int nowSlot;

    // �̱���
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //���� ���� �־����

        path = Application.persistentDataPath + "/save"; //
    }
    void Start()
    {
        
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        //��� ���, ���(data)
        //�����̸� �ڿ� ��ȣ���� �ٿ���
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}
