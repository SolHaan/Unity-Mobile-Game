using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : Singleton<InputManager>
{
    protected Vector2 _movement = Vector2.zero;
    protected bool _isJump = false;
    protected bool _isAttack = false;

    public Vector2 Movement { get { return _movement; } }

    public bool IsJump { get { return _isJump; } }

    public bool isAttack { get { return _isAttack; } }

    public virtual void SetMovement(Vector2 movement)
    {
        _movement.x = movement.x;
        _movement.y = movement.y;
    }

    public void StartJump()
    {
        if (_isJump)
        {
            return;
        }

        _isJump = true;
    }

    public void ClearJumpFlag() //위에서 계속 점프하니까 false로 변경
    {
        if (!_isJump)
        {
            return;
        }

        _isJump = false;
    }

    public void StartAttack()
    {
        if (_isAttack)
        {
            return;
        }

        _isAttack = true;
    }
}