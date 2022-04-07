using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBManager : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/11Mzqm2A9EfK58SftNQtXxEuipDYEPqPYu4ZIj_Sephc/export?format=tsv&gid=792217208&range=A2:B";

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        print(data);
    }
}
