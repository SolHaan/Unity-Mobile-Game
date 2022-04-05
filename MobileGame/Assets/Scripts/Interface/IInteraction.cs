public enum InteractionType
{
    NPC,
    Enemy,
    Monster,
    Princess,
}

//�÷��̾��� ���ͷ���
public interface IInteraction
{
    InteractionType interType { get; }
    bool isinterObj { get; set; } //���ͷ����� �������� ���� üũ��, ���â�� ������������ �ƹ��� �ൿ�� ���� �ʵ��� �ؾ���
    void ShowInteraction(); //��ü�� �������� ���ϴ� �ൿ, �� ������ ���
    void EndInteraction(); //���ͷ��� ���� �� ó��
    void NonShowInteraction(); //��ü�� �������� �ϸ� �ȵǴ� �ൿ, �ʿ������ ���� ���� �ʴ°ɷ�
}