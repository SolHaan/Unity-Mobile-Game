using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class Character
{
    //string player;
    //string enemy;
    //string princess;

    Queue<string> player;
    Queue<string> enemy;
    Queue<string> princess;

    public Character(Queue<string> _player, Queue<string> _enemy, Queue<string> _princess)
    {
        this.player = _player;
        this.enemy = _enemy;
        this.princess = _princess;
    }

    //public Character(string _player, string _enemy, string _princess)
    //{
    //    this.player = _player;
    //    this.enemy = _enemy;
    //    this.princess = _princess;
    //}

    public void ShowTalk()
    {
        //playerTalk.Enqueue(this.player);
        //enemyTalk.Enqueue(this.enemy);
        //princessTalk.Enqueue(this.princess);

        //Debug.Log(playerTalk.Peek());
        //Debug.Log(enemyTalk.Peek());
        //Debug.Log(princessTalk.Peek());

        Debug.Log("주인공 : " + this.player);
        Debug.Log("적 : " + this.enemy);
        Debug.Log("공주 : " + this.princess);
    }
}

public class DBManager : Singleton<DBManager>
{
    const string URL = "https://docs.google.com/spreadsheets/d/11Mzqm2A9EfK58SftNQtXxEuipDYEPqPYu4ZIj_Sephc/export?format=csv&range=A2:D";
    string data;
    public Dictionary<string, Character> dataTable;
    public Hashtable dbtable;

    public Queue<string> characterTalk;

    IEnumerator Start()
    {
        dataTable = new Dictionary<string, Character>();
        characterTalk = new Queue<string>();

        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        data = www.downloadHandler.text;

        string[] data_line = data.Split('\n');

        for (int i = 0; i < data_line.Length; i++)
        {
            string[] data_lineSplit = data_line[i].Split(',');
            //dataTable.Add(data_lineSplit[0], new Character(data_lineSplit[1], data_lineSplit[2], data_lineSplit[3]));

            characterTalk.Enqueue(data_lineSplit[1]);
            characterTalk.Enqueue(data_lineSplit[2]);
            characterTalk.Enqueue(data_lineSplit[3]);

            //dataTable.Add(data_lineSplit[0], new Character(data_lineSplit[1], data_lineSplit[2], data_lineSplit[3]));
        }

        //foreach (KeyValuePair<string, Character> pair in dataTable)
        //{
        //    character = pair.Value;
        //    character.ShowTalk();
        //}
    }
}
