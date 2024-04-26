using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [Header ("Menus")]
    public GameObject MainMenu;
    public GameObject AccountMenu;
    //public GameObject LobbyST;
    public GameObject LobbyMenu;
    public GameObject LobbyLoadMenu;
    public GameObject SettingsMenu;
    public GameObject InfoMenu;
    public GameObject KeysMenu;
    public GameObject CustomMenu;
    public GameObject TitleText;

    [Header ("Carga")]
    public static bool isInLoad;
    public bool isLoading;

    [Header ("Temporizador")]
    public static float stimer;
    public float timer;
    public static float smaxTime;
    public float maxTime = 15f;

    [Header ("Audio")]
    public AudioSource Button;

    void Start()
    {
        MainMenu.SetActive(true);
        LobbyMenu.SetActive(false);
        LobbyLoadMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(false);
        KeysMenu.SetActive(false);
        TitleText.SetActive(true);
        CustomMenu.SetActive(false);
        //LobbyST.SetActive(true);

        isInLoad = false;

        Button.GetComponent<AudioSource>();

        chatActived = false;
    }

    public void Return()
    {
        MainMenu.SetActive(true);
        LobbyMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(false);
        KeysMenu.SetActive(false);
        TitleText.SetActive(true);
        CustomMenu.SetActive(false);

        Button.Play();

        chatActived = false;
    }

    public void Settings()
    {
        MainMenu.SetActive(false);
        LobbyMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        InfoMenu.SetActive(false);
        KeysMenu.SetActive(false);
        CustomMenu.SetActive(false);
        TitleText.SetActive(true);

        Button.Play();

        chatActived = false;
    }

    public void Keys()
    {
        MainMenu.SetActive(false);
        LobbyMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(false);
        KeysMenu.SetActive(true);
        TitleText.SetActive(false);
        CustomMenu.SetActive(false);

        Button.Play();

        chatActived = false;
    }

    public void Account()
    {
        MainMenu.SetActive(false);
        AccountMenu.SetActive(true);
        LobbyMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(false);
        KeysMenu.SetActive(false);
        CustomMenu.SetActive(false);
        TitleText.SetActive(false);

        Button.Play();

        chatActived = false;
    }

    public void Lobby()
    {
        MainMenu.SetActive(false);
        LobbyMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(false);
        TitleText.SetActive(true);
        CustomMenu.SetActive(false);

        Button.Play();

        chatActived = false;
    }

    public void Customize()
    {
        MainMenu.SetActive(false);
        LobbyMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(false);
        TitleText.SetActive(false);
        CustomMenu.SetActive(true);

        Button.Play();

        chatActived = false;
    }

    public void Info()
    {
        MainMenu.SetActive(false);
        LobbyMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(true);
        KeysMenu.SetActive(false);
        TitleText.SetActive(true);
        CustomMenu.SetActive(false);

        Button.Play();

        chatActived = false;
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        chatActived = false;
    }

    public void Quit()
    {
        Application.Quit();

        Button.Play();

        chatActived = false;
    }

    public static bool chatActived;

    public void Chat()
    {
        chatActived = true;
    }

    void Update()
    {
        isLoading = isInLoad;

        if (isInLoad)
        {
            MainMenu.SetActive(false);
            LobbyMenu.SetActive(false);
            LobbyLoadMenu.SetActive(true);
            SettingsMenu.SetActive(false);
            KeysMenu.SetActive(false);
            TitleText.SetActive(true);

            stimer += Time.deltaTime;
        }

        else {stimer = 0;}

        timer = stimer;
        smaxTime = maxTime;
    }

    public void SinglePlayer()
    {
        Rounds._thisRound = 1;
        SceneManager.LoadScene("RoomSelector");
    }
}