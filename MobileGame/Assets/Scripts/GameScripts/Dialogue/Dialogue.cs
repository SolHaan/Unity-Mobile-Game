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

    public Queue<string> talk01;

    void Start()
    {
        talk01 = DBManager.Instance.characterTalk01;
    }

    public void NextTalk()
    {
        if (talk01.Count == 0)
            return;

        switch (GameManager.Instance.dialogue)
        {
            case 1:
                if (talkCnt == 17)
                {
                    btnZone.SetActive(false);
                    StartCoroutine(Talk01ObjDelay());
                    talk01.Dequeue();
                    talkCnt++;
                    //sDataManager.Instance.nowPlayer.dialogueNum++;
                    return;
                }
                NowDialogue();
                break;

            case 2:
                if (talkCnt == 20)
                {
                    btnZone.SetActive(false);
                    StartCoroutine(Talk02ObjDelay());
                    talk01.Dequeue();
                    //sDataManager.Instance.nowPlayer.dialogueNum++;
                    return;
                }
                NowDialogue();
                break;

            case 3:
                Debug.Log(talkCnt);
                if (talkCnt == 33)
                {
                    btnZone.SetActive(false);
                    GameManager.Instance.endingImg.SetActive(true);
                    //StartCoroutine(Talk03ObjDelay());
                    //sDataManager.Instance.nowPlayer.dialogueNum++;
                    return;
                }
                NowDialogue();
                break;
        }
    }

    void NowDialogue()
    {
        if (talk01.Peek().Length == 0 || talk01.Peek().Length == 1)
        {
            talkCnt++;
            talk01.Dequeue();
        }

        talkCnt++;

        switch (talkCnt % 3)
        {
            case 1:
                //talkTxt.text = DataManager.Instance.nowPlayer.playerName + " : " + DBManager.Instance.characterTalk.Peek();
                talkTxt.text = "플레이어 : " + talk01.Peek(); //나중에 위로 바꿀꺼임
                break;

            case 2:
                talkTxt.text = "보스 : " + talk01.Peek();
                if (talkCnt == 23)
                {
                    btnZone.SetActive(false);
                    StartCoroutine(EnemyDeadtalk());
                }
                else if (talk01.Peek().Length > 6)
                {
                    btnZone.SetActive(false);
                    StartCoroutine(ExclamationEffect());
                }
                break;

            case 0:
                talkTxt.text = "공주 : " + talk01.Peek();
                break;
        }
        talk01.Dequeue();
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

    IEnumerator EnemyDeadtalk()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.boss.SetActive(false);

        yield return new WaitForSeconds(1f);
        talkTxt.text = "문이 열렸다.";
        GameManager.Instance.prison.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        btnZone.SetActive(true);
    }

    IEnumerator Talk01ObjDelay()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.enemy02.SetActive(false);
        GameManager.Instance.princess.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        talkTxt.text = "도착한 마왕성...";
        gameObject.SetActive(false);
        noTalkSet.SetActive(true);
        btnZone.SetActive(true);
    }

    IEnumerator Talk02ObjDelay()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        noTalkSet.SetActive(true);
        btnZone.SetActive(true);
    }
}
