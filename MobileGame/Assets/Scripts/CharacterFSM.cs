using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    Idle = 0,
    Jump = 1,
    Run = 2,
    Attack = 3,
    Death = 4,
}

public class CharacterFSM : MonoBehaviour
{
    protected PlayerController playerController;
    public CharacterState state { get; set; }

    protected bool isNewState { get; set; }

    protected virtual void Awake()
    {
        //characterBase = GetComponent<>
        playerController = GameManager.I.player;
    }

    protected virtual void OnEnable()
    {
        state = CharacterState.Idle;
        StartCoroutine(ChangeState());
    }

    private IEnumerator ChangeState()
    {
        while(true)
        {
            isNewState = false;
            yield return StartCoroutine(state.ToString());
        }
    }

    public void SetState(CharacterState newState)
    {
        if(state != newState)
        {
            isNewState = true;
            state = newState;


        }
    }
}
