using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterController : MonoBehaviour
{
    public enum Type { M1, M2, M3, Bomb, Trap1, Trap2 };
    public Type type;
    public int damage;
    public int monstercurHp;

    int bombDuration = 3;
    int bombDelayTime = 10;

    void OnEnable()
    {
        Sequence mSequence = DOTween.Sequence();

        switch (type)
        {
            case Type.M1:
            case Type.M2:
            case Type.M3:
                gameObject.transform.DOLocalMoveX(gameObject.transform.position.x + 5, 1).SetLoops(-1, LoopType.Yoyo);
                break;

            case Type.Bomb:
                mSequence.Append(gameObject.transform.DOMoveX(gameObject.transform.position.x, 0).SetDelay(bombDelayTime))
                         .Append(gameObject.transform.DOLocalMoveX(-50, bombDuration).SetLoops(-1))
                         .Append(gameObject.transform.DOMoveX(gameObject.transform.position.x, 0));

                StartCoroutine(BombDelay());
                break;

            case Type.Trap1:
                gameObject.transform.DOLocalMoveY(gameObject.transform.position.y - 0.35f, 2).SetLoops(-1, LoopType.Yoyo);
                break;

            case Type.Trap2:
                gameObject.transform.DOLocalMoveY(gameObject.transform.position.y - 20, 1.5f).SetLoops(-1, LoopType.Yoyo);
                break;
        }
    }

    IEnumerator BombDelay()
    {
        yield return new WaitForSeconds(bombDelayTime + bombDuration);

        if (gameObject == GameManager.Instance.bomb[0])
        {
            GameManager.Instance.bomb[0].SetActive(false);

            GameManager.Instance.bomb[1].SetActive(true);
        }
        else if (gameObject == GameManager.Instance.bomb[1])
        {
            GameManager.Instance.bomb[1].SetActive(false);

            GameManager.Instance.bomb[0].SetActive(true);
        }
    }
}
