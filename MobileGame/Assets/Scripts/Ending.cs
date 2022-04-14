using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Ending : MonoBehaviour
{
    GameObject openImg;

    public Vector3 playerFirstPos = new Vector3(-5, -2, 0);
    int fadeTime = 2;

    void Start()
    {
        BossStageOpen();
    }

    public void BossStageOpen()
    {
        openImg = GameManager.Instance.initialImg;

        openImg.SetActive(true);

        Sequence cSequence = DOTween.Sequence();

        cSequence.Append(openImg.GetComponent<Image>().DOFade(0, fadeTime).SetDelay(fadeTime))
                 .Append(openImg.GetComponent<Image>().DOFade(1, fadeTime));

        DOTween.Kill(transform);

        GameManager.Instance.player.transform.position = playerFirstPos;

        StartCoroutine(ImgSetDelay());
    }

    IEnumerator ImgSetDelay()
    {
        yield return new WaitForSeconds(fadeTime * 2);
        openImg.SetActive(false);
    }
}
