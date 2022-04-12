using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            MonsterDamage col = collision.GetComponent<MonsterDamage>();
            if (col.type == MonsterDamage.Type.M1 || col.type == MonsterDamage.Type.M2 || col.type == MonsterDamage.Type.M3)
            {
                //col.monstercurHp -= DataManager.Instance.nowPlayer.power;
                col.GetComponent<SpriteRenderer>().color = Color.gray;

                col.MonsterDead();
            }
        }
        gameObject.SetActive(false);
    }
}
