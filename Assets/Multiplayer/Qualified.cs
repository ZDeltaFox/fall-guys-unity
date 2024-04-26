using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Qualified : MonoBehaviour
{
    public bool isSurvival;
    public float[] players;
    public static float _DeathPlayers;
    public float deathPlayers;
    public float[] maxQualify;
    public static float[] _maxQualify;
    //public float[] maxDeath;
    public float qualifieds;
    public float realPlayersQualified;
    public static float _RealPlayersQualified;
    public static float _Qualifieds;
    public bool isChangingRoom;
    public static bool IsChangingRoom;

    void Update()
    {
        _maxQualify = maxQualify;
        if (_Qualifieds > 0.5)
        {
            if (!isSurvival)
            {
                if (qualifieds >= maxQualify[Rounds._thisRound - 1] - 0.5)
                {
                    StartCoroutine(Text2());
                }
            }

            else
            {
                if (deathPlayers >= maxQualify[Rounds._thisRound - 1] - 0.5 || realPlayersQualified >= PlayerID._players - 0.5)
                {
                    StartCoroutine(Text1());
                }
            }
        }

        qualifieds = _Qualifieds;
        deathPlayers = _DeathPlayers;
        realPlayersQualified = _RealPlayersQualified;
        isChangingRoom = IsChangingRoom;

        if (PhotonNetwork.InRoom)
        {
            maxQualify[0] = Mathf.Round((PhotonNetwork.CurrentRoom.PlayerCount / 3) * 2);
            maxQualify[1] = Mathf.Round((PhotonNetwork.CurrentRoom.PlayerCount / 3) * 1);
            maxQualify[2] = 1;
        }
    }

    void Start()
    {
        IsChangingRoom = false;
        _RealPlayersQualified = 0;
        _DeathPlayers = 0;
        _Qualifieds = 0;
    }

    IEnumerator Text1() 
    {
        yield return new WaitForSeconds(0.1f); 
        if (realPlayersQualified >= PlayerID._players - 0.5) 
        {
            Debug.Log("All Players (or bots) are classified, next round");
            IsChangingRoom = true;
        }
    }

    IEnumerator Text2() 
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("All Players are eliminated, next round");
        IsChangingRoom = true;
    }
}
