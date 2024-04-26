using UnityEngine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PlayerID : MonoBehaviourPunCallbacks
{
    public bool applyDontDestroyOnLoad;
    [Header ("Tag")]
    public string playerTag;
    public static string _PlayerTag;
    [Header ("ID")]
    public int ID;
    public static int _ID;
    bool isInRoom;

    [Header ("Players")]
    public float Players;
    public static float _players;

    void Update()
    {
        // Obtener el PhotonPlayer del jugador local
        //PhotonPlayer localPlayer = PhotonNetwork.LocalPlayer;

        // Obtener el ActorNumber del jugador local
        //_ID = localPlayer.ActorNumber;

        if (PhotonNetwork.InRoom)
        {
            _ID = PhotonNetwork.LocalPlayer.ActorNumber;
        }

        else
        {
            _ID = 1;
        }

        /*// Buscar un PhotonPlayer específico por su ID
        int playerId = 2; // ID del jugador que quieres buscar
        PhotonPlayer player = PhotonPlayer.Find(playerId);

        // Obtener el número de actor del jugador encontrado
        int playerActorNumber = player.ActorNumber;*/
        _players = Players;

        if (isInRoom) {Players = PhotonNetwork.CurrentRoom.PlayerCount;}
        if (_ID != ID) {ID = _ID;}
        if (_PlayerTag != playerTag) {playerTag = _PlayerTag;}

        if (_PlayerTag != PlayerPrefs.GetString("Username")) {_PlayerTag = PlayerPrefs.GetString("Username");}
    }

    #region Don't Destroy On Load
    private static PlayerID instance;

    private void Awake()
    {
        if (applyDontDestroyOnLoad)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion
    #region PhotonPun

    public override void OnJoinedRoom()
    {
        _ID = PhotonNetwork.CurrentRoom.PlayerCount;
        isInRoom = true;
    }

    public override void OnLeftRoom()
    {
        _ID = 0;
        isInRoom = false;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (_ID >= Players + 1) {_ID--;}
    }

    public void OnBackToMainMenuPressed()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
