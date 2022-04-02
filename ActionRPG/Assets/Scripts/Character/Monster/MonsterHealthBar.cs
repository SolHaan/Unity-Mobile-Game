using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthBar : MonoBehaviour
{
    //몬스터들의 체력바 
    protected virtual void OnEnable()
    {
        StartCoroutine(MonsterDamage());
    }

    private IEnumerator MonsterDamage()
    {
        //이 오브젝트가 활성화되면 데미지가 -2 받는다.
        //맞았다는 표시로 빨간색이 된다.
        yield return new WaitForSeconds(3f);
        //3초가 끝나면 이 오브젝트는 비활성화된다.
    }

    //체력이 0 이하면 죽음(비활성화)
    ///죽을때 행동정지 및 color.gray
    //죽고 5초 뒤 생성(활성화)
}
