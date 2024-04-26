using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerCounter : MonoBehaviourPunCallbacks
{
    public float fPlayerCounter;
    public static float SPlayerCounter;

    void Update()
    {
        fPlayerCounter = PhotonNetwork.CurrentRoom.PlayerCount;
        SPlayerCounter = fPlayerCounter;
    }
}
