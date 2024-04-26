using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameSelect : MonoBehaviour
{
    public TMP_InputField nameInput;

    void Start()
    {
        if (PlayerPrefs.HasKey("Username"))
        {
            nameInput.text = PlayerPrefs.GetString("Username");
        }

        else
        {
            nameInput.text = "Player" + Random.Range(0000, 9999).ToString("0000");
            PlayerPrefs.SetString("Username", nameInput.text);
        }
    }

    public void ChangeName()
    {
        PlayerPrefs.SetString("Username", nameInput.text);
    }
}
