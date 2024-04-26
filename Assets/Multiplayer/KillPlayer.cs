using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class KillPlayer : MonoBehaviour
{
    public static bool playerIsKilled;
    public static bool isResetting;

    void Start() 
    {
        playerIsKilled = false;
        isResetting = false;
    }

    void Update()
    {
        if (isResetting)
        {
            StartCoroutine(SetKilled());
        }
    }

    public IEnumerator SetKilled()
    {
        playerIsKilled = false;
        isResetting = false;
        SceneManager.LoadScene("MainMenu");
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.LeaveRoom();
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.Disconnect();
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
}
