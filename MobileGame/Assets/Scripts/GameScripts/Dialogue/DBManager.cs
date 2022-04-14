using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class DBManager : Singleton<DBManager>
{
    const string Dialogue01 = "https://docs.google.com/spreadsheets/d/11Mzqm2A9EfK58SftNQtXxEuipDYEPqPYu4ZIj_Sephc/export?format=csv&range=A2:D";
    const string Dialogue02 = "https://docs.google.com/spreadsheets/d/11Mzqm2A9EfK58SftNQtXxEuipDYEPqPYu4ZIj_Sephc/export?format=csv&gid=1406314912&range=A2:D";
    const string Dialogue03 = "https://docs.google.com/spreadsheets/d/11Mzqm2A9EfK58SftNQtXxEuipDYEPqPYu4ZIj_Sephc/export?format=csv&gid=29859768&range=A2:D";
    string data01, data02, data03;

    public Queue<string> characterTalk01;
    public Queue<string> characterTalk02;
    public Queue<string> characterTalk03;

    IEnumerator Start()
    {
        characterTalk01 = new Queue<string>();
        characterTalk02 = new Queue<string>();
        characterTalk03 = new Queue<string>();

        UnityWebRequest www01 = UnityWebRequest.Get(Dialogue01);
        UnityWebRequest www02 = UnityWebRequest.Get(Dialogue02);
        UnityWebRequest www03 = UnityWebRequest.Get(Dialogue03);
        yield return www01.SendWebRequest();

        //

        dataInQ(data01, www01, characterTalk01);
        dataInQ(data01, www01, characterTalk02);
        dataInQ(data01, www01, characterTalk03);

        //data01 = www01.downloadHandler.text;
        //data02 = www01.downloadHandler.text;
        //data03 = www01.downloadHandler.text;

        //string[] data_line = data01.Split('\n');

        //for (int i = 0; i < data_line.Length; i++)
        //{
        //    string[] data_lineSplit = data_line[i].Split(',');

        //    characterTalk01.Enqueue(data_lineSplit[1]);
        //    characterTalk01.Enqueue(data_lineSplit[2]);
        //    characterTalk01.Enqueue(data_lineSplit[3]);
        //}
    }

    void dataInQ(string data, UnityWebRequest www, Queue<string> talk)
    {
        data = www.downloadHandler.text;

        string[] data_line = data.Split('\n');

        for (int i = 0; i < data_line.Length; i++)
        {
            string[] data_lineSplit = data_line[i].Split(',');

            for (int j = 1; j < data_lineSplit.Length; j++)
            {
                talk.Enqueue(data_lineSplit[j]);
            }
        }
    }
}
