using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : Singleton<DataManager>
{
    public PlayerData nowPlayer = new PlayerData();

    public string path;
    public int nowSlot;

    // 싱글톤
    public override void Awake()
    {
        DontDestroyOnLoad(gameObject);

        path = Application.persistentDataPath + "/save"; //
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        //어디 경로, 어떤거(data)
        //파일이름 뒤에 번호까지 붙여줌
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
