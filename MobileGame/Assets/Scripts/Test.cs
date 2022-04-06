using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 1. 데이터(코드 = 클래스)를 만들어야함. => 저장할 데이터 생성
// 2. 그 데이터를 Json으로 변환. (택배상자로 포장)
// ===================================================
// 1. Json(택배)를 다시 원래의 코드로 바꾸는 방법
// ﻿제이슨(택배) -> 조립도 -> 클래스(코드)

class Data //저장하고 싶은 모든걸 넣으면 됨.(ex. 플레이어 정보)
{
    public string nickname;
    public int level;
    public int coin = 100;
    public bool skill;
    //기타 등등...
}

public class Test : MonoBehaviour
{
    Data player = new Data() { nickname = "한솔", level = 50, coin = 200, skill = false};

    void Start()
    {
        //2. json으로 변환
        string jsonData = JsonUtility.ToJson(player);

        Data player2 = JsonUtility.FromJson<Data>(jsonData);

        //Debug.Log(player2.nickname);
        //Debug.Log(player2.level);
        //Debug.Log(player2.coin);
        //Debug.Log(player2.skill);
    }
}
