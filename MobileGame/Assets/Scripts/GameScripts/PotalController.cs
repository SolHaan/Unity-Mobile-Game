using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PotalController : MonoBehaviour
{
    public Vector3 playerFirstPos = new Vector3(-5, -2, 0);
    int fadeTime = 2;

    GameObject img;

    void Start()
    {
        img = GameManager.Instance.initialImg;
    }

    public void NextStage()
    {
        img.SetActive(true);

        StageSet(GameManager.Instance.Round, false);

        GameManager.Instance.Round ++;

        if (GameManager.Instance.Round > 3)
        {
            Debug.Log(GameManager.Instance.Round);
            //GameManager.Instance.player.GetComponent<PlayerController>().
            GameManager.Instance.dialogue++;
            StartCoroutine(BossStageSet());
            return;
        }

        Sequence nSequence = DOTween.Sequence();

        nSequence.Append(img.GetComponent<Image>().DOFade(0, fadeTime).SetDelay(fadeTime))
                 .Append(img.GetComponent<Image>().DOFade(1, fadeTime));

        GameManager.Instance.monstersAllObj.SetActive(false);
        GameManager.Instance.player.transform.position = playerFirstPos;
        GameManager.Instance.player.GetComponent<BoxCollider2D>().enabled = true;

        StartCoroutine(UISetDelay());
    }

    IEnumerator UISetDelay()
    {
        yield return new WaitForSeconds(fadeTime / 2);
        StageSet(GameManager.Instance.Round - 1, true);

        yield return new WaitForSeconds(fadeTime * 1.5f);
        img.SetActive(false);
        GameManager.Instance.monstersAllObj.SetActive(true);
    }

    void StageSet(int num, bool isSet)
    {
        GameManager.Instance.stageSpawner[num - 1].SetActive(isSet);
        GameManager.Instance.fieldBackground[num - 1].SetActive(isSet);
        switch (num)
        {
            case 1:
            case 2:
                GameManager.Instance.fieldRoad[0].SetActive(isSet);
                break;

            case 3:
                GameManager.Instance.fieldRoad[1].SetActive(isSet);
                break;
        }
    }

    IEnumerator BossStageSet()
    {
        GameManager.Instance.frame.SetActive(false);
        GameManager.Instance.generalStage.SetActive(false);
        GameManager.Instance.noTalk.SetActive(false);

        GameManager.Instance.talk.SetActive(true);
        GameManager.Instance.bossStage.SetActive(true);

        Sequence nSequence = DOTween.Sequence();

        nSequence.Append(img.GetComponent<Image>().DOFade(0, fadeTime).SetDelay(fadeTime))
                 .Append(img.GetComponent<Image>().DOFade(1, fadeTime));

        GameManager.Instance.monstersAllObj.SetActive(false);
        GameManager.Instance.player.transform.position = playerFirstPos;
        GameManager.Instance.player.GetComponent<BoxCollider2D>().enabled = true;

        yield return new WaitForSeconds(fadeTime * 1.5f);
        img.SetActive(false);
    }
}
