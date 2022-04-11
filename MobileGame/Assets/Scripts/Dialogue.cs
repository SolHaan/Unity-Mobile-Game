using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text talkTxt;
    public int talkCnt;

    public GameObject enemy01;
    public GameObject enemy02;
    public GameObject princess;

    public GameObject btnZone;
    public GameObject noTalkSet;

    public void NextTalk()
    {
        if (DBManager.Instance.characterTalk.Count == 0)
            return;

        if (DBManager.Instance.characterTalk.Peek().Length == 0 || DBManager.Instance.characterTalk.Peek().Length == 1)
        {
            talkCnt++;
            DBManager.Instance.characterTalk.Dequeue();
        }

        talkCnt++;

        switch (talkCnt % 3)
        {
            case 1:
                //talkTxt.text = DataManager.Instance.nowPlayer.playerName + " : " + DBManager.Instance.characterTalk.Peek();
                talkTxt.text = "플레이어 : " + DBManager.Instance.characterTalk.Peek(); //나중에 위로 바꿀꺼임
                break;

            case 2:
                talkTxt.text = "보스 : " + DBManager.Instance.characterTalk.Peek();
                if (DBManager.Instance.characterTalk.Peek().Length > 6)
                {
                    StartCoroutine(ExclamationEffect());
                    btnZone.SetActive(false);
                }
                break;

            case 0:
                talkTxt.text = "공주 : " + DBManager.Instance.characterTalk.Peek();
                break;
        }
        DBManager.Instance.characterTalk.Dequeue();

        if (talkCnt == 17)
        {
            btnZone.SetActive(false);
            StartCoroutine(TalkObjDelay());
            return;
        }
    }

    IEnumerator ExclamationEffect()
    {
        yield return new WaitForSeconds(1.5f);
        enemy01.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        talkTxt.text = "보스 : 안돼!!!!!!";

        yield return new WaitForSeconds(1f);
        Destroy(enemy01);
        talkTxt.text = "";
        btnZone.SetActive(true);
    }

    IEnumerator TalkObjDelay()
    {
        yield return new WaitForSeconds(1.5f);
        enemy02.SetActive(false);
        princess.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
        noTalkSet.SetActive(true);
    }
}
