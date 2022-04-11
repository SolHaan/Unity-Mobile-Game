using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreate : MonoBehaviour
{
    GameObject monster01Spawn;
    GameObject monster02Spawn;
    GameObject monster03Spawn;
    GameObject TrapSpawn;

    void Start()
    {
        monster01Spawn = GameManager.Instance.monsterSpawner[0];
        monster02Spawn = GameManager.Instance.monsterSpawner[1];
        monster03Spawn = GameManager.Instance.monsterSpawner[2];
        TrapSpawn = GameManager.Instance.monsterSpawner[3];
    }

    void OnEnable()
    {
        GameManager.Instance.monsters.SetActive(true);

        StartCoroutine(Trapdd());
    }

    IEnumerator Trapdd()
    {
        //연습용으로 만든거
        //이부분을 사용해서 몬스터 활성화 시키면
        //랜덤 스폰 만들기
        yield return new WaitForSeconds(1f);
        TrapSpawn.SetActive(false);
    }
}
