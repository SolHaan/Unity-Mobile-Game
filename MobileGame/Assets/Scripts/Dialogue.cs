using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    Dictionary<string, Character> talkTableDic;

    void Start()
    {
        talkTableDic = DBManager.Instance.dataTable;

        //foreach (KeyValuePair<string,Character> pair in DBManager.Instance.dataTable)
        //{
        //    Character character = pair.Value;
        //    character.ShowTalk();
        //}
    }
}
