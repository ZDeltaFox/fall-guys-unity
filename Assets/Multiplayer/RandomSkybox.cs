using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Photon.Pun;
using Photon.Realtime;

public class RandomSkybox : MonoBehaviour
{
    private PhotonView pv;
    public Material[] skyboxMaterial;
    void Start()
    {
        pv = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            pv.RPC("ChangeSkybox", RpcTarget.AllBuffered, Random.Range(1, skyboxMaterial.Length));
        }
    }

    [PunRPC]
    void ChangeSkybox(int i)
    {
        RenderSettings.skybox = skyboxMaterial[i - 1];
        Debug.LogWarning("Skybox changed to: " + i);
    }
}
