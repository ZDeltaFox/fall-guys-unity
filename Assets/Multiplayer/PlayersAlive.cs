using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PlayersAlive : MonoBehaviourPunCallbacks
{
    public float totalPlayers;
    public static float sTotalPlayers;
    public byte actualPlayers;
    public static float sActualPlayers;
    public byte playersAlive;
    public float deathPlayers;
    float posX;
    public static float sPosX;
    float posZ;
    public static float sPosZ;
    public string finalText;
    public static string sFinalText;

    //public GameObject ImpostorWin;
    public GameObject Canvas;

    void Update()
    {
        if (LobbyNetworkManager.MyPlayerNumberCounter == 1)
        {
            //deathPlayers = MultiplayerPlayerController.SusPlayerMovement.sTotalKilled;

            if (CloseRoom.sTimeToClose <= CloseRoom.sMaxTime)
            {
                totalPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
            }

            else
            {
                if (actualPlayers <= 1.2)
                {
                    StartCoroutine(IWin());
                }
            }

            playersAlive = PhotonNetwork.CurrentRoom.PlayerCount;

            gameObject.transform.position = new Vector3(playersAlive, 1000, deathPlayers);     
        }

        else
        {
            if (CloseRoom.sTimeToClose >= CloseRoom.sMaxTime)
            {
                if (actualPlayers <= 1.2)
                {
                    StartCoroutine(IWin());
                }
            }
        }

        //actualPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
        actualPlayers = playersAlive;

        playersAlive = PhotonNetwork.CurrentRoom.PlayerCount;

        sFinalText = finalText;

        posX = gameObject.transform.position.x;
        sPosX = posX;

        posZ = gameObject.transform.position.z;
        sPosZ = posZ;

        sTotalPlayers = totalPlayers;
        sActualPlayers = actualPlayers;
    }

    public IEnumerator IWin()
    {
        StartCoroutine(ReturnLobby());
        //if (LobbyNetworkManager.MyPlayerNumberCounter == 1) {finalText = "Victoria";}
        //else {finalText = "Derrota";}
        //MultiplayerPlayerController.SusPlayerMovement.canMove = false;
        //MultiplayerPlayerController.SusPlayerMovement.isSDeath = true;
        //ImpostorWin.SetActive(true);
        //Canvas.SetActive(false);
        //MultiplayerPlayerController.SusPlayerMovement.growpWin = true;
        yield return new WaitForSeconds(7f);
        //StartCoroutine(ReturnLobby());
    }

    public IEnumerator ReturnLobby()
    {
        //MultiplayerPlayerController.SusPlayerMovement.growpWin = false;
        SceneManager.LoadScene("MainMenu");
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
        yield return new WaitForSeconds(0.25f);  
    }

    void Start()
    {
        //MultiplayerPlayerController.SusPlayerMovement.growpWin = false;
    }
}
