using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    bool runDown;

    float hAxis;
    float vAxis;

    Vector3 moveVec;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
        Move();
    }

    void GetInput()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        runDown = Input.GetButton("Run");
    }

    //¿Ãµø
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * (runDown ? 0.5f : 0.3f) * Time.deltaTime;

        anim.SetBool("isRun", runDown);
        anim.SetBool("isWalk", moveVec != Vector3.zero);
    }
}
