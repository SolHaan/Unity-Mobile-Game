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

    public GameObject initialImg;

    public int Round;
}
