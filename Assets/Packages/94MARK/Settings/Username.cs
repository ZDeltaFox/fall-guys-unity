using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Username : MonoBehaviour
{
    public TMP_Text username;

    void Awake()
    {
        if (PlayerPrefs.HasKey("Username"))
        {
            username.text = PlayerPrefs.GetString("Username");
        }

        else
        {
            username.text = "Player" + Random.Range(0000, 9999).ToString("0000");
            string Username;
            Username = username.text;
            PlayerPrefs.SetString("Username", Username);

            //PlayerPrefs.DeleteKey("Username");
        }
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("Username"))
        {
            username.text = PlayerPrefs.GetString("Username");
        }

        if (Input.GetKey("left ctrl"))
        {
            if (Input.GetKey("left shift"))
            {
                if (Input.GetKey("d"))
                {
                    if (Input.GetKey("k"))
                    {
                        PlayerPrefs.DeleteKey("Username");
                        Debug.Log("Username.Tag ha sido eliminado. Username.Tag se va a regenerar");
                        SetName();
                    }
                }
            }
        }
    }

    void SetName()
    {
        username.text = "Player" + Random.Range(0000, 9999).ToString("0000");
        string Username;
        Username = username.text;
        PlayerPrefs.SetString("Username", Username);
    }
}
