using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthBar : MonoBehaviour
{
    //���͵��� ü�¹� 
    protected virtual void OnEnable()
    {
        StartCoroutine(MonsterDamage());
    }

    private IEnumerator MonsterDamage()
    {
        //�� ������Ʈ�� Ȱ��ȭ�Ǹ� �������� -2 �޴´�.
        //�¾Ҵٴ� ǥ�÷� �������� �ȴ�.
        yield return new WaitForSeconds(3f);
        //3�ʰ� ������ �� ������Ʈ�� ��Ȱ��ȭ�ȴ�.
    }

    //ü���� 0 ���ϸ� ����(��Ȱ��ȭ)
    ///������ �ൿ���� �� color.gray
    //�װ� 5�� �� ����(Ȱ��ȭ)
}
