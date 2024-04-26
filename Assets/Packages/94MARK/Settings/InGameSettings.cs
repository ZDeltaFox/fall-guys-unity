using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSettings : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject SettingsMenu;

    public static bool inSettings;
    public bool Sets;
    public bool Pause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.F3) || Input.GetKeyDown("p"))
        {
            Pause = !Pause;
            Sets = false;
        }

        if (Sets || Pause) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inSettings = true;
        }

        else 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inSettings = false;
        }

        PauseMenu.SetActive(Pause);
        SettingsMenu.SetActive(Sets);
    }

    public void Return()
    {
        Pause = !Pause;
        Sets = false;
    }

    public void Settings()
    {
        Sets = true;
        Pause = false;
    }
}
