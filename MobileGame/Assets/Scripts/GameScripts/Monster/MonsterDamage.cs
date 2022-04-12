using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonsterController
{
    public void playerDamage()
    {
        //DataManager.Instance.nowPlayer.curHp -= damage;
        GameManager.Instance.player.GetComponent<SpriteRenderer>().color = Color.red;
        GameManager.Instance.player.GetComponent<BoxCollider2D>().enabled = false;

        StartCoroutine(playerDamageDelay());
    }

    IEnumerator playerDamageDelay()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.player.GetComponent<SpriteRenderer>().color = Color.white;

        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.player.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void MonsterDead()
    {
        if(monstercurHp < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
