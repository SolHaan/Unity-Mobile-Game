using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
                    talkCnt++;
                    //sDataManager.Instance.nowPlayer.dialogueNum++;
                    return;
                }
                NowDialogue();
                break;

            case 3:
                if (talkCnt == 31)
                {
                    btnZone.SetActive(false);
                    StartCoroutine(Talk03ObjDelay());
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
                talkTxt.text = "ÇÃ·¹ÀÌ¾î : " + talk01.Peek(); //³ªÁß¿¡ À§·Î ¹Ù²Ü²¨ÀÓ
                break;

            case 2:
                talkTxt.text = "º¸½º : " + talk01.Peek();
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
                talkTxt.text = "°øÁÖ : " + talk01.Peek();
                break;
        }
        talk01.Dequeue();
    }

    IEnumerator ExclamationEffect()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.enemy01.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        talkTxt.text = "º¸½º : ¾ÈµÅ!!!!!!";

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
        talkTxt.text = "¹®ÀÌ ¿­·È´Ù.";
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
        talkTxt.text = "µµÂøÇÑ ¸¶¿Õ¼º...";
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
        talkTxt.text = "½Â¸®ÇÑ ¿µ¿õ!!";
    }

    IEnumerator Talk03ObjDelay()
    {
        GameManager.Instance.endingImg.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("LoadScene");
    }
}
