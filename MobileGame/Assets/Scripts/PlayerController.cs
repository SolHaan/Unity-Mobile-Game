using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterFSM
{
    public int item; //나중에 배열로 바꿔야할지도?

    //이동
    public float speed;

    //점프
    public float jumpHeight;
    int jumpCount = 0;
    int limitJumpCount = 2;

    Rigidbody2D rigid;
    SpriteRenderer playerRender;
    public Animator anim;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerRender = FindObjectOfType<PlayerController>().GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        SetState(CharacterState.Idle);

        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * InputManager.Instance.Movement.y;
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * InputManager.Instance.Movement.x;

        if(InputManager.Instance.Movement.x < 0f) { playerRender.flipX = true; }
        else if(InputManager.Instance.Movement.x > 0f) { playerRender.flipX = false; }

        transform.position += upMovement;
        transform.position += rightMovement;
    }

    public void Jump()
    {
        if (InputManager.Instance == null)
        {
            return;
        }

        if (InputManager.Instance.IsJump)
        {
            if (jumpCount < limitJumpCount)
            {
                jumpCount = jumpCount + 1;
                rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision.GetComponent<IItem>();

        if(item != null)
        {
            item.Use();
        }
    }
}
