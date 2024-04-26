using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Keyboard : MonoBehaviour
{
    public InputField inputField;

    private TouchScreenKeyboard keyboard;

    public void OnInputFieldSelected()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        //keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);
    }

    private void Update()
    {
        if (keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Done)
        {
            inputField.text = keyboard.text;
            keyboard = null;
        }
    }
}