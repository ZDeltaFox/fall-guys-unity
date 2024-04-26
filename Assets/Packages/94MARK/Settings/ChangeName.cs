using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeName : MonoBehaviour
{
    [Header ("Name")]
    public string playerName;
    public TMP_Text playerInputName;

    [Header ("Menu")]
    public GameObject thisMenu;
    public GameObject mainMenu;

    public void ConfirmName()
    {
        
        playerName = playerInputName.text;

        if (playerName != null)
        {
            PlayerPrefs.SetString("Username", playerName);
        }
    }

    public void Return()
    {
        playerInputName.text = "";
        mainMenu.SetActive(true);
        thisMenu.SetActive(false);
    }
}
