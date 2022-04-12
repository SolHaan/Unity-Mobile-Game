using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PotalController : MonoBehaviour
{
    public GameObject ChangeSceneImg;

    public Vector3 playerFirstPos = new Vector3(-5, -2, 0);

    int fadeTime = 6;

    public void NextStage()
    {
        ChangeSceneImg.SetActive(true);

        GameManager.Instance.StageSpawner[GameManager.Instance.Round - 1].SetActive(false);
        GameManager.Instance.Round++;
        GameManager.Instance.monstersAllObj.SetActive(false);
        GameManager.Instance.player.transform.position = playerFirstPos;

        Sequence cSequence = DOTween.Sequence();

        cSequence.Append(ChangeSceneImg.GetComponent<Image>().DOFade(1, fadeTime / 2))
                 .Append(ChangeSceneImg.GetComponent<Image>().DOFade(0, fadeTime / 2));

        StartCoroutine(UISetDelay());
    }

    IEnumerator UISetDelay()
    {
        yield return new WaitForSeconds(fadeTime);
        ChangeSceneImg.SetActive(false);

        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.monstersAllObj.SetActive(true);

        yield return new WaitForSeconds(0.1f);
        StageMonster(GameManager.Instance.Round);
    }

    void StageMonster(int num)
    {
        GameManager.Instance.StageSpawner[num - 1].SetActive(true);
    }
}
