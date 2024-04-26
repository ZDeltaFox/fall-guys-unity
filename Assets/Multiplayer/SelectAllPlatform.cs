using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SelectAllPlatform : MonoBehaviour
{
    private PhotonView pv;

    public GameObject passable1;
    public GameObject passable2;
    public GameObject passable3;
    public GameObject passable4;
    public GameObject passable5;
    public GameObject passable6;
    public GameObject passable7;
    public GameObject passable8;
    public GameObject passable9;
    public GameObject passable0;

    public GameObject[] noPassable1;
    public GameObject[] noPassable2;
    public GameObject[] noPassable3;
    public GameObject[] noPassable4;
    public GameObject[] noPassable5;
    public GameObject[] noPassable6;
    public GameObject[] noPassable7;
    public GameObject[] noPassable8;
    public GameObject[] noPassable9;
    public GameObject[] noPassable0;

    public int[] allSelections;

    void Awake()
    {
        pv = GetComponent<PhotonView>();
        allSelections[0] = Random.Range(1, noPassable1.Length);

        allSelections[1] = allSelections[1] + Random.Range(-2, 2);
        if (allSelections[1] - 1 < 1) {allSelections[1]++;}
        if (allSelections[1] > noPassable1.Length) {allSelections[1]--;}

        allSelections[2] = allSelections[1] + Random.Range(-2, 2);
        if (allSelections[2] - 1 < 1) {allSelections[2]++;}
        if (allSelections[2] > noPassable1.Length) {allSelections[2]--;}

        allSelections[3] = allSelections[2] + Random.Range(-2, 2);
        if (allSelections[3] - 1 < 1) {allSelections[3]++;}
        if (allSelections[3] > noPassable1.Length) {allSelections[3]--;}
        
        allSelections[4] = allSelections[3] + Random.Range(-2, 2);
        if (allSelections[4] - 1 < 1) {allSelections[4]++;}
        if (allSelections[4] > noPassable1.Length) {allSelections[4]--;}

        allSelections[5] = allSelections[4] + Random.Range(-2, 2);
        if (allSelections[5] - 1 < 1) {allSelections[5]++;}
        if (allSelections[5] > noPassable1.Length) {allSelections[5]--;}      

        allSelections[6] = allSelections[5] + Random.Range(-2, 2);
        if (allSelections[6] - 1 < 1) {allSelections[6]++;}
        if (allSelections[6] > noPassable1.Length) {allSelections[6]--;}
        
        allSelections[7] = allSelections[6] + Random.Range(-2, 2);
        if (allSelections[7] - 1 < 1) {allSelections[7]++;}
        if (allSelections[7] > noPassable1.Length) {allSelections[7]--;}

        allSelections[8] = allSelections[7] + Random.Range(-2, 2);
        if (allSelections[8] - 1 < 1) {allSelections[8]++;}
        if (allSelections[8] > noPassable1.Length) {allSelections[8]--;}

        allSelections[9] = allSelections[8] + Random.Range(-2, 2);
        if (allSelections[9] - 1 < 1) {allSelections[9]++;}
        if (allSelections[9] > noPassable1.Length) {allSelections[9]--;}

        if (PhotonNetwork.InRoom)
        {
            pv = GetComponent<PhotonView>();
            if (PhotonNetwork.IsMasterClient)
            {
                pv.RPC("Select", RpcTarget.AllBuffered, allSelections);
            }
        }

        else
        {
            Select(allSelections);
        }
    }

    [PunRPC]
    void Select(int[] i)
    {
        for (int j = 0; j < i.Length - 1; j++)
        {
            passable0.transform.position = noPassable0[i[j] - 1].transform.position;
            noPassable0[i[j] - 1].SetActive(false);
            Debug.Log("PosChanged, Platform: " + j + "Line: " + i);
        }    

        allSelections = i;

        Select(i);
    }
}
