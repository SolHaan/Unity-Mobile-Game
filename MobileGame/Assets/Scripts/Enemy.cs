using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int enemyCurHp = 100;
    public GameObject prison;

    public void EnemyDamage()
    {
        //DataManager.Instance.nowPlayer.curHp -= damage;
        GameManager.Instance.player.GetComponent<SpriteRenderer>().color = Color.red;
        GameManager.Instance.player.GetComponent<BoxCollider2D>().enabled = false;

        StartCoroutine(EnemyDamageDelay());
    }

    IEnumerator EnemyDamageDelay()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.player.GetComponent<SpriteRenderer>().color = Color.white;

        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.player.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void EnemyDead()
    {
        StartCoroutine(DeadDelay());
        //GameManager.Instance.boss.SetActive(false);
        //GameManager.Instance.prison.SetActive(false);

        //enemyCurHp--;
        //Debug.Log(enemyCurHp);

        //if (enemyCurHp < 0)
        //{
        //    gameObject.SetActive(false);
        //    prison.SetActive(false);
        //}
    }

    IEnumerator DeadDelay()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.dialogue++;
        GameManager.Instance.noTalk.SetActive(false);
        GameManager.Instance.talk.SetActive(true);
    }
}
