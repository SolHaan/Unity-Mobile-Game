using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text playerName;
    public Text level;
    public Slider maxHp;
    public Slider curHp;
    Dialogue dialogue;

    GameObject player;

    Vector3 checkPos;
    //public Text coin; //추후 상점도입하면 넣을 예정

    void Awake()
    {
        player = GameManager.Instance.player;
        dialogue = GetComponent<Dialogue>();
    }

    void Start()
    {
        checkPos = DataManager.Instance.nowPlayer.playerPos;

        playerName.text = DataManager.Instance.nowPlayer.playerName;
        level.text += DataManager.Instance.nowPlayer.level.ToString(); //int를 string으로 변환해야함.
        maxHp.maxValue = DataManager.Instance.nowPlayer.maxHp;
        curHp.value = DataManager.Instance.nowPlayer.curHp;
        player.transform.position = DataManager.Instance.nowPlayer.playerPos;
        player.GetComponent<SpriteRenderer>().flipX = DataManager.Instance.nowPlayer.playerFilp;
    }

    public void Save()
    {
        DataManager.Instance.nowPlayer.playerPos = player.transform.position; //위치 저장

        if (player.transform.position != checkPos)
        {
            DataManager.Instance.SaveData();
        }

        DataManager.Instance.nowPlayer.round = GameManager.Instance.Round;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GamePause()
    {
        Time.timeScale = 0;
    }

    public void GamePlay()
    {
        Time.timeScale = 1;
    }
}
