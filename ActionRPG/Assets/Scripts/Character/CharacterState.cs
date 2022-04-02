using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public Animator Anim { get; set; }

    protected virtual void Awake()
    {
        Anim = GetComponent<Animator>();
    }
}
