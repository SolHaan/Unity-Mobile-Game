using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    bool isJump;
    bool isDodge;

    bool runDown;
    bool jumpDown;
    bool dodgeDown;

    float hAxis;
    float vAxis;

    Vector3 moveVec;
    Vector3 dodgeVec;

    Animator anim;
    Rigidbody rigid;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
        Move();
        Jump();
        Dodge();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        runDown = Input.GetButton("Run");
        jumpDown = Input.GetButtonDown("Jump");
        dodgeDown = Input.GetButtonDown("Dodge");
    }

    //이동
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (isDodge)
            moveVec = dodgeVec;

        transform.position += moveVec * speed * (runDown ? 0.5f : 0.3f) * Time.deltaTime;

        anim.SetBool("isRun", runDown);
        anim.SetBool("isWalk", moveVec != Vector3.zero);

        //회전
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if (jumpDown && !isJump && !isDodge)
        {
            rigid.AddForce(Vector3.up * 12, ForceMode.Impulse);
            //anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void Dodge()
    {
        if(dodgeDown && moveVec != Vector3.zero && !isDodge && !isJump)
        {
            dodgeVec = moveVec;
            speed *= 2;
            anim.SetTrigger("doDodge");
            isDodge = true;

            Invoke("DodgeOut", 0.4f);
        }
    }

    void DodgeOut()
    {
        speed *= 0.5f;
        isDodge = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            //anim.SetBool("isJump", false);
            isJump = false;
        }
    }
}
