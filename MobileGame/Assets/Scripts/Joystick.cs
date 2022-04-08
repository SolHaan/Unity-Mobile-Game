using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class MyEvent : UnityEvent<Vector2> { }

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [Header("Camera")]
    public Camera TargetCamera;

    [Header("Axis")]
    public float MaxRange = 1f;

    [Header("Binding")]
    public MyEvent JoystickValue;

    //
    protected Vector2 _neutralPosition;
    protected Vector2 _joystickValue;
    protected Vector2 _newTargetPosition;
    protected Vector3 _newJoystickPosition;

    protected virtual void Start()
    {
        Initialize();
    }

    protected virtual void OnEnable()
    {
        Initialize();
    }

    public virtual void Initialize()
    {
        _neutralPosition = GetComponent<RectTransform>().transform.position;
    }

    protected virtual void Update()
    {
        if (JoystickValue == null)
        {
            return;
        }

        // �Է°� ����
        _joystickValue.x = EvaluateInputValue(_newTargetPosition.x);
        _joystickValue.y = EvaluateInputValue(_newTargetPosition.y);

        JoystickValue.Invoke(_joystickValue);
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        // ���̽�ƽ ��ġ ����
        _newTargetPosition = TargetCamera.ScreenToWorldPoint(eventData.position);
        _newTargetPosition = Vector2.ClampMagnitude(_newTargetPosition - _neutralPosition, MaxRange);
        _newJoystickPosition = _neutralPosition + _newTargetPosition;

        // ���̽�ƽ ��ġ ����
        transform.position = _newJoystickPosition;
        var localPos = transform.localPosition;
        transform.localPosition = new Vector3(localPos.x, localPos.y, 0f);
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        // �ʱⰪ���� ����
        _newJoystickPosition = _neutralPosition;
        transform.position = _newJoystickPosition;
        var localPos = transform.localPosition;
        transform.localPosition = new Vector3(localPos.x, localPos.y, 0f);

        _newTargetPosition = Vector2.zero;
        _joystickValue.x = 0f;
        _joystickValue.y = 0f;
    }

    protected virtual float EvaluateInputValue(float vectorPosition)
    {
        return Mathf.InverseLerp(0, MaxRange, Mathf.Abs(vectorPosition)) * Mathf.Sign(vectorPosition);
    }
}