using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    public UnityEvent onPlayerDead;

    private void Dead()
    {
        onPlayerDead.Invoke();

        Debug.Log("ав╬З╢ы!");
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Dead();
    }
}
