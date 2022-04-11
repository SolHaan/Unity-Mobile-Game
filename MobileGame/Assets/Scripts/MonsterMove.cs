using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterMove : MonoBehaviour
{
    public enum Type { M1, M2, M3, Bomb, Trap };
    public Type type;
    public int damage;

    void OnEnable()
    {
        switch (type)
        {
            case Type.M1:
            case Type.M2:
            case Type.M3:
                gameObject.transform.DOLocalMoveX(gameObject.transform.position.x + 5, 1).SetLoops(-1, LoopType.Yoyo);
                break;

            case Type.Bomb:
                gameObject.transform.DOLocalMoveX(-50, 1);
                //원래자리로 복귀 추가하기
                break;

            case Type.Trap:
                gameObject.transform.DOLocalMoveY(gameObject.transform.position.y - 0.35f, 1).SetLoops(-1, LoopType.Yoyo);
                break;
        }
    }
}
