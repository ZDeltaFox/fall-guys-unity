using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameSettingsButtons : MonoBehaviourPunCallbacks
{
    public GameObject UIImpostor;
    public GameObject UIMenu;
    public GameObject Abandonar;
    public GameObject Settings;
    public GameObject Map;
    //public GameObject SabotageMap;

    public float PNumber;

    bool MapB;
    //bool MapSabotageB;

    bool canSabotage;

    void Start()
    {
        canSabotage = true;
        UIImpostor.SetActive(false);
        UIMenu.SetActive(true);
        Abandonar.SetActive(false);
        Settings.SetActive(false);
        Map.SetActive(false);
        //MultiplayerPlayerController.SusPlayerMovement.canMove = true;
    }

    void Update()
    {
        PNumber = LobbyNetworkManager.MyPlayerNumberCounter;

        Map.SetActive(MapB);
        //SabotageMap.SetActive(MapSabotageB);

        if (Input.anyKey && MapB && !Input.GetKey("m")) 
        {
            MapB = false;
            //MultiplayerPlayerController.SusPlayerMovement.canMove = true;
        }

        //if (MapB) {MapSabotageB = false;}
        //if (MapSabotageB) {MapB = false;}

        //if (Input.anyKey && MapSabotageB && !Input.GetKey("mouse 0") && !Input.GetKey("mouse 1") && !Input.GetKey("b")) 
        //{
            //MapSabotageB = false;
            ////MultiplayerPlayerController.SusPlayerMovement.canMove = true;
        //}

        //if (//MultiplayerPlayerController.SusPlayerMovement.isInMission) {canSabotage = false;}

        if (canSabotage)
        {
            if (Input.GetKey("m"))
            {
                MapB = true;
                Map.SetActive(true);
                //MultiplayerPlayerController.SusPlayerMovement.canMove = false;
            }

            //if (Input.GetKey("b"))
            //{
                //if (PNumber == 1)
                //{
                    //MapSabotageB = true;
                    //SabotageMap.SetActive(true);
                    ////MultiplayerPlayerController.SusPlayerMovement.canMove = false;
                //}
            //}
        }

        else
        {
            MapB = false;
            //MapSabotageB = false;
        }
    }

    public void SettingsMenu()
    {
        //MultiplayerPlayerController.SusPlayerMovement.canMove = false;
        UIImpostor.SetActive(false);
        UIMenu.SetActive(false);
        Abandonar.SetActive(false);
        Settings.SetActive(true);

        canSabotage = false;
    }

    public void QuitConfirm()
    {
        UIImpostor.SetActive(false);
        UIMenu.SetActive(false);
        Abandonar.SetActive(true);
        Settings.SetActive(false);

        canSabotage = false;
    }

    public void Return()
    {
        UIImpostor.SetActive(true);
        UIMenu.SetActive(true);
        Abandonar.SetActive(false);
        Settings.SetActive(false);

        ////MultiplayerPlayerController.SusPlayerMovement.canMove = true;

        canSabotage = true;
    }

    public void Quit() 
    {
        StartCoroutine(OnQuitButton());
    }

    public IEnumerator OnQuitButton()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("MainMenu");
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.LeaveRoom();
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.Disconnect();
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
        yield return new WaitForSeconds(0.25f);
    }

    public void MapBtn() {MapB = true; 
    //MultiplayerPlayerController.SusPlayerMovement.canMove = false;
    }

    //public void SabotageBtn() {MapSabotageB = true; //MultiplayerPlayerController.SusPlayerMovement.canMove = false;}
}
