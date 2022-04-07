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

    //public int coin; //추후 상점구현 시 추가
    //public int seletCharacter; //추후 캐릭터 생성 구현 시 추가
}
