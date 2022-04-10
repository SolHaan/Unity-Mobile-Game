using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class Character
{
    string player;
    string enemy;
    string princess;

    public Character(string _player, string _enemy, string _princess)
    {
        this.player = _player;
        this.enemy = _enemy;
        this.princess = _princess;
    }

    public void ShowTalk()
    {
        Debug.Log(this.player);
        Debug.Log(this.enemy);
        Debug.Log(this.princess);
    }
}

public class DBManager : Singleton<DBManager>
{
    const string URL = "https://docs.google.com/spreadsheets/d/11Mzqm2A9EfK58SftNQtXxEuipDYEPqPYu4ZIj_Sephc/export?format=csv&range=A2:D";

    string data;

    public Dictionary<string, Character> dataTable;

    IEnumerator Start()
    {
        dataTable = new Dictionary<string, Character>();

        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        data = www.downloadHandler.text;

        string[] data_line = data.Split('\n');

        for (int i = 0; i < data_line.Length; i++)
        {
            string[] data_lineSplit = data_line[i].Split(',');
            dataTable.Add(data_lineSplit[0], new Character(data_lineSplit[1], data_lineSplit[2], data_lineSplit[3]));
        }

        foreach (KeyValuePair<string, Character> pair in dataTable)
        {
            Character character = pair.Value;
            character.ShowTalk();
            //흠 이렇게는 되는데 왜 Dialogue에서는 안될까...
        }
    }
}
