using UnityEngine;

//[CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Object/Player Data", order = int.MaxValue)]
[System.Serializable]
public class PlayerData //: ScriptableObject
{
    public string playerName;
    public int level = 1;
    public int maxHp = 100;
    public int curHp = 100;
    public Vector3 playerPos = new Vector3(-6, -2.5f, 0);
    public bool playerFilp;

    //public int coin; //���� �������� �� �߰�
    //public int seletCharacter; //���� ĳ���� ���� ���� �� �߰�
}
