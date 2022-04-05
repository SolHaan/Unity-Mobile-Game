public enum InteractionType
{
    NPC,
    Enemy,
    Monster,
    Princess,
}

//플레이어의 인터랙션
public interface IInteraction
{
    InteractionType interType { get; }
    bool isinterObj { get; set; } //인터랙션이 가능한지 상태 체크용, 대사창이 열려있을때는 아무런 행동을 하지 않도록 해야함
    void ShowInteraction(); //객체를 만났을때 취하는 행동, 적 만나면 대사
    void EndInteraction(); //인터랙션 끝난 후 처리
    void NonShowInteraction(); //객체를 만났을때 하면 안되는 행동, 필요없으면 굳이 쓰지 않는걸로
}