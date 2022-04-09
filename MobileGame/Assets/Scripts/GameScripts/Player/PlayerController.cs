using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int item; //나중에 배열로 바꿔야할지도?

    //이동
    public float speed;

    //점프
    public float jumpHeight;
    int jumpCount = 0;
    int limitJumpCount = 1;

    //공격
    int attackCount = 0;
    public GameObject attackBtn;

    Rigidbody2D rigid;
    SpriteRenderer playerRender;
    Animator anim;
    public GameObject attackZone;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerRender = GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * InputManager.Instance.Movement.x;

        if(InputManager.Instance.Movement.x < 0f) { playerRender.flipX = true; }
        else if(InputManager.Instance.Movement.x > 0f) { playerRender.flipX = false; }

        transform.position += rightMovement;

        StartCoroutine(Idle());
    }

    IEnumerator Idle()
    {
        yield return null;
        if (Joystick.isJoystickDrag) { anim.SetInteger("stat", 1); }
        else { anim.SetInteger("stat", 0); }
    }

    public void Jump()
    {
        if (jumpCount < limitJumpCount)
        {
            jumpCount++;
            rigid.AddForce(Vector2.up * jumpHeight * speed, ForceMode2D.Impulse);
            StartCoroutine(JumpAnim());
        }
    }

    IEnumerator JumpAnim()
    {
        anim.SetTrigger("doJump");
        yield return new WaitForSeconds(0.5f);
        jumpCount = 0;
    }

    public void Attack()
    {
        attackCount++;
        StartCoroutine(AttackAnim());
    }

    IEnumerator AttackAnim()
    {
        attackBtn.GetComponent<Image>().color = Color.red;
        attackBtn.GetComponentInChildren<Text>().text = "연속공격!";

        switch (attackCount)
        {
            case 1:
                anim.SetInteger("AttackStat", 1);
                break;

            case 2:
                anim.SetInteger("AttackStat", 2);
                break;

            case 3:
                anim.SetInteger("AttackStat", 3);
                break;
        }
        
        yield return null;
        anim.SetInteger("AttackStat", 0);

        yield return new WaitForSeconds(1f);
        attackCount = 0;
        attackBtn.GetComponent<Image>().color = Color.white;
        attackBtn.GetComponentInChildren<Text>().text = "공격";
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
