using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    public GameObject enemy01;
    public GameObject enemy02;
    public GameObject princess;
    public GameObject monsters;

    public GameObject[] bomb;
    public GameObject[] monsterSpawner;
}
