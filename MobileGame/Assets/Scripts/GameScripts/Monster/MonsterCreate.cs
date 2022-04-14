using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreate : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.monstersAllObj.SetActive(true);

        GameManager.Instance.stageSpawner[0].SetActive(true);
    }
}
