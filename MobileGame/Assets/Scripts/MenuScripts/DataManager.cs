using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//저장하는 방법
// 1. 저장할 데이터가 존재
// 2. 데이터를 제이슨으로 변환
// 3. 제이슨을 외부에 저장

//불러오는 방법
// 1. 외부에 저장된 제이슨을 가져옴
// 2. 제이슨을 데이터형태로 변환
// 3. 불러온 데이터를 사용

public class PlayerData
{
    // 이름, 레벨, 코인, 착용중인 무기
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

    // 싱글톤
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //게임 내내 있어야함

        path = Application.persistentDataPath + "/save"; //
    }
    void Start()
    {
        
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
