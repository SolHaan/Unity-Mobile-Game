using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour, IItem
{
    public int dropObj = 1;

    public void Use()
    {
        //Debug.Log(gameObject.name + "�� �����!");

        PlayerController player = FindObjectOfType<PlayerController>();
        //player.item += dropObj;

        gameObject.SetActive(false);
    }
}
