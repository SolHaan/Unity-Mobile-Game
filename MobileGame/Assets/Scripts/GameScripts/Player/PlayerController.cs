using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //이동
    public float speed;

    //점프
    public float jumpHeight;
    int jumpCount = 0;
    int limitJumpCount = 1;

    //공격
    int attackCount = 0;
    public GameObject attackBtn;
    public GameObject nextBtn;

    public GameObject reBtn;

    Rigidbody2D rigid;
    SpriteRenderer playerRender;
    Animator anim;
    public GameObject jumpEffect;
    public GameObject attackZone;

    //player Stat
    public Slider playerHp;
    int playerPower = 10;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerRender = GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(GameManager.Instance.initialImg.activeSelf == false)
        {
            Move();
        }
        else
        {
            anim.SetInteger("stat", 0);
        }
    }

    public void Move()
    {
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * InputManager.Instance.Movement.x;

        if(InputManager.Instance.Movement.x < 0f) {
            playerRender.flipX = true;
            jumpEffect.transform.localPosition = new Vector3(0.6f, 0, 0);
            attackZone.transform.localPosition = new Vector3(-2, 0, 0);
        }
        else if(InputManager.Instance.Movement.x > 0f) {
            playerRender.flipX = false;
            jumpEffect.transform.localPosition = new Vector3(-0.6f, 0, 0);
            attackZone.transform.localPosition = new Vector3(0, 0, 0);
        }

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
            rigid.constraints = RigidbodyConstraints2D.None;
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

        yield return new WaitForSeconds(0.5f);
        rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
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
        #region 나중에 추가
        //IItem item = collision.GetComponent<IItem>();
        //if (item != null)
        //{
        //    item.Use();
        //}
        #endregion
        MonsterDamage monster = collision.GetComponent<MonsterDamage>();
        Enemy enemy = collision.GetComponent<Enemy>();

        MonsterController.Type type = collision.GetComponent<MonsterController>().type;

        if(collision.gameObject.tag == "Potal")
        {
            nextBtn.SetActive(true);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (attackZone.activeSelf == true)
            {
                collision.GetComponent<SpriteRenderer>().color = Color.yellow;
                StartCoroutine(DamageDelay(collision));
                enemy.EnemyDead();
            }
            else
            {
                enemy.EnemyDamage();
            }
        }

        if (collision.tag == "Monster")
        {
            if (attackZone.activeSelf == true)
            {
                switch (type)
                {
                    case MonsterController.Type.M1:
                    case MonsterController.Type.M2:
                    case MonsterController.Type.M3:
                        collision.GetComponent<SpriteRenderer>().color = Color.yellow;
                        StartCoroutine(DamageDelay(collision));
                        monster.monstercurHp -= playerPower;
                        monster.MonsterDead();
                        break;
                }
            }
            else
            {
                if (playerHp.value == 0)
                {
                    //죽음
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    anim.SetTrigger("doDie");
                    //게임오버, 재시작 버튼
                    StartCoroutine(PlayerDieDelay());
                }
                else
                {
                    monster.playerDamage();
                    PlayerHpDown(type);
                }
            }
        }
    }

    IEnumerator DamageDelay(Collider2D col)
    {
        yield return new WaitForSeconds(0.2f);
        col.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void PlayerHpDown(MonsterController.Type type)
    {
        switch (type)
        {
            case MonsterController.Type.M1:
                playerHp.value -= 10;
                break;

            case MonsterController.Type.M2:
                playerHp.value -= 20;
                break;

            case MonsterController.Type.M3:
                playerHp.value -= 30;
                break;

            case MonsterController.Type.Bomb:
                playerHp.value -= 50;
                break;

            case MonsterController.Type.Trap1:
            case MonsterController.Type.Trap2:
                playerHp.value -= 5;
                break;
        }

        //if (playerHp.value == 0)
        //{
        //    //죽음
        //    GameManager.Instance.player.GetComponent<BoxCollider2D>().enabled = false;
        //    anim.SetTrigger("doDie");
        //    //게임오버, 재시작 버튼
        //    StartCoroutine(PlayerDieDelay());
        //    return;
        //}
    }

    IEnumerator PlayerDieDelay()
    {
        yield return new WaitForSeconds(2);
        //재시작 버튼 활성화
        GameManager.Instance.noTalk.SetActive(false);
        reBtn.SetActive(true);
    }

    public void RetryPlayer()
    {
        playerHp.value = 100;
        transform.position = new Vector3(-5, -2, 0);
        playerRender.flipX = false;
        anim.SetTrigger("doRevive");
        GameManager.Instance.noTalk.SetActive(true);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        StartCoroutine(MonsterSpawnDelay(GameManager.Instance.Round));
    }

    IEnumerator MonsterSpawnDelay(int num)
    {
        GameManager.Instance.stageSpawner[num - 1].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.stageSpawner[num - 1].SetActive(true);
    }
}
