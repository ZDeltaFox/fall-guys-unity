using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SelectDoor : MonoBehaviour
{
    public GameObject[] breakableDoor;
    public GameObject[] noBreakableDoor;

    public bool onlyOne;

    private PhotonView pv;

    void Awake()
    {
        if (PhotonNetwork.InRoom)
        {
            pv = GetComponent<PhotonView>();
            if (PhotonNetwork.IsMasterClient)
            pv.RPC("Select", RpcTarget.AllBuffered, Random.Range(1, noBreakableDoor.Length), Random.Range(1, noBreakableDoor.Length));
        }

        else
        {
            Select(Random.Range(1, noBreakableDoor.Length), Random.Range(1, noBreakableDoor.Length));
        }
    }

    [PunRPC]
    void Select(int i, int i2)
    {
        if (i == i2) {if (i2 == noBreakableDoor.Length) {i2--;} else {i2++;}}

        breakableDoor[0].transform.position = noBreakableDoor[i - 1].transform.position;
        noBreakableDoor[i - 1].SetActive(false);
        if (!onlyOne)
        {
            breakableDoor[1].transform.position = noBreakableDoor[i2 - 1].transform.position;
            noBreakableDoor[i2 - 1].SetActive(false);
        }
    }
}
