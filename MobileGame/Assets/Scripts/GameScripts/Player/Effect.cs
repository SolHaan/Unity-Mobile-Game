using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public void OnEnable()
    {
        StartCoroutine(EffectOff());
    }

    IEnumerator EffectOff()
    {
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
    }
}
