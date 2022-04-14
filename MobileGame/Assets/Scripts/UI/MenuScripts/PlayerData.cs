using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int level = 1;
    public int maxHp = 100;
    public int curHp = 100;
    public Vector3 playerPos = new Vector3(-5, -2, 0);
    public bool playerFilp;
    public int power = 10;

    public int round = 1;
    public int dialogueNum = 1;
}
