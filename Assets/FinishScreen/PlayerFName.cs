using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerFName : MonoBehaviour
{
    public TMP_Text name;

    void Start()
    {
        name.text = PlayerPrefs.GetString("Username");
    }
}
