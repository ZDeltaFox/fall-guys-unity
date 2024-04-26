using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent (typeof (PhotonView))]

public class PlayerName : MonoBehaviour
{
    private PhotonView pv;
    public string name;
    void Start()
    {
        pv = GetComponent<PhotonView>();
        name = PlayerPrefs.GetString("Username");
        if (pv.IsMine)
        {
            pv.RPC("SetName", RpcTarget.OthersBuffered, name);
            GetName(name);
        }
    }

    [PunRPC]
    void SetName(string user)
    {
        GetName(user);
    }

    void GetName(string user)
    {
        GetComponent<TMP_Text>().text = user;
    }
}
