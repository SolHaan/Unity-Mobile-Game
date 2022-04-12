using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreate : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.monstersAllObj.SetActive(true);

        GameManager.Instance.StageSpawner[0].SetActive(true);
    }
}
