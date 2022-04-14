using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text talkTxt;
    public int talkCnt;

    public GameObject btnZone;
    public GameObject noTalkSet;
    //public GameObject enemy01;
    //public GameObject enemy02;
    //public GameObject princess;

    public Queue<string> talk01, talk02, talk03;
    int talkNum = 1;

    void Start()
    {
        talk01 = DBManager.Instance.characterTalk01;
        talk02 = DBManager.Instance.characterTalk02;
        talk03 = DBManager.Instance.characterTalk03;
    }

    public void NextTalk()
    {
        if (talk01 == null || talk02 == null || talk03 == null)
            return;

        switch (talkNum)
        {
            case 1:
                if (talk01.Count == 1)
                {
                    btnZone.SetActive(false);
                    StartCoroutine(Talk01ObjDelay());
                    //sDataManager.Instance.nowPlayer.dialogueNum++;
                    return;
                }
                NowDialogue(talk01);
                break;

            case 2:
                NowDialogue(talk02);
                break;

            case 3:
                NowDialogue(talk03);
                break;
        }
    }

    void NowDialogue(Queue<string> talk)
    {
        if (talk.Peek().Length == 0 || talk.Peek().Length == 1)
        {
            talkCnt++;
            talk.Dequeue();
        }

        talkCnt++;

        switch (talkCnt % 3)
        {
            case 1:
                //talkTxt.text = DataManager.Instance.nowPlayer.playerName + " : " + DBManager.Instance.characterTalk.Peek();
                talkTxt.text = "플레이어 : " + talk.Peek(); //나중에 위로 바꿀꺼임
                break;

            case 2:
                talkTxt.text = "보스 : " + talk.Peek();
                if (talk.Peek().Length > 6)
                {
                    btnZone.SetActive(false);
                    StartCoroutine(ExclamationEffect());
                }
                break;

            case 0:
                talkTxt.text = "공주 : " + talk.Peek();
                break;
        }
        talk.Dequeue();
    }

    IEnumerator ExclamationEffect()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.enemy01.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        talkTxt.text = "보스 : 안돼!!!!!!";

        yield return new WaitForSeconds(1f);
        Destroy(GameManager.Instance.enemy01);
        talkTxt.text = "";
        btnZone.SetActive(true);
    }

    IEnumerator Talk01ObjDelay()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.enemy02.SetActive(false);
        GameManager.Instance.princess.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
        noTalkSet.SetActive(true);
    }
}
