using UnityEngine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LeaveInGame : MonoBehaviourPunCallbacks
{
    public void LeaveRoom()
    {
        StartCoroutine(ReloadRooms());
    }

    public IEnumerator ReloadRooms()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
}
