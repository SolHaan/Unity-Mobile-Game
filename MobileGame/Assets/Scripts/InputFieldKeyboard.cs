using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldKeyboard : MonoBehaviour
{
    [SerializeField]
    private TouchScreenKeyboard keyboard;

    public void OnSelectEvent()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
