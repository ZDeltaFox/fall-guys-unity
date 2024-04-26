using UnityEngine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

[RequireComponent (typeof (PhotonView))]
public class RandomName : MonoBehaviour
{
    private PhotonView photonView;

    public TMP_Text tName;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    
    void Start()
    {
        if (PlayerID._ID == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            if (photonView.IsMine)
            {
                string name = PlayerPrefs.GetString("Username");
                photonView.RPC("SetName", RpcTarget.AllBuffered, name);
            }
        }

        gameObject.transform.SetParent(LobbyNetworkManager.playerListParent.transform);
    }

    [PunRPC]
    void SetName(string name)
    {
        tName.text = name;
    }
}
