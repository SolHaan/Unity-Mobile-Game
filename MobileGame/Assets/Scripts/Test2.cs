using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public delegate void Boost(Test2 target);

    public event Boost playerBoost;

    public string playerName = "anso";
    public float hp = 100;
    public float damage = 10;

    void Start()
    {
        playerBoost(this);
    }
}

