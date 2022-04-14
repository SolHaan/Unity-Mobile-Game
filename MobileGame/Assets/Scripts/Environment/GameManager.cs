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
    public GameObject[] stageSpawner;
    public GameObject[] fieldBackground;
    public GameObject[] fieldRoad;

    [Header("Boss")]
    public GameObject frame;
    public GameObject generalStage;
    public GameObject bossStage;
    public GameObject noTalk;
    public GameObject talk;
    public GameObject boss;
    public GameObject prison;

    public GameObject endingImg;

    public GameObject initialImg;

    public int Round;
    public int dialogue;
}
