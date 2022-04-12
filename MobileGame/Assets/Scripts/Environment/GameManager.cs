using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Characters")]
    public GameObject player;
    public GameObject enemy01;
    public GameObject enemy02;
    public GameObject princess;

    [Header("Monster")]
    public GameObject monstersAllObj;
    public GameObject[] bomb;
    public GameObject[] StageSpawner;

    //[Header("Potal Obj")]
    //public GameObject uiSet;
    //public GameObject ChangeSceneImg;

    public int Round;
}
