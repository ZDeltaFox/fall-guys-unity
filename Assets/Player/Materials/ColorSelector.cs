using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ColorSelector : MonoBehaviour
{
    public bool isPlayer;
    private PhotonView pv;
    public Material[] material;
    public int[] colorNumber;
    public float[] metallic;
    public float[] smoothness;

    void Start()
    {
        pv = GetComponent<PhotonView>();

        if (isPlayer)
        {
            colorNumber[0] = PlayerPrefs.GetInt("color0");
            metallic[0] = PlayerPrefs.GetFloat("metal0");
            smoothness[0] = PlayerPrefs.GetFloat("Smooth0");

            colorNumber[1] = PlayerPrefs.GetInt("color1");
            metallic[1] = PlayerPrefs.GetFloat("metal1");
            smoothness[1] = PlayerPrefs.GetFloat("Smooth1");

            colorNumber[2] = PlayerPrefs.GetInt("color2");
            metallic[2] = PlayerPrefs.GetFloat("metal2");
            smoothness[2] = PlayerPrefs.GetFloat("Smooth2");

            if (pv.IsMine)
            {
                pv.RPC("SetColor", RpcTarget.OthersBuffered, colorNumber[0], metallic[0], smoothness[0], colorNumber[1], metallic[1], smoothness[1], colorNumber[2], metallic[2], smoothness[2]);
                GetColor(colorNumber[0], metallic[0], smoothness[0], colorNumber[1], metallic[1], smoothness[1], colorNumber[2], metallic[2], smoothness[2]);
            }
        }

        else
        {
            if (PhotonNetwork.IsMasterClient)
            {
                pv.RPC("SetColor", RpcTarget.OthersBuffered, Random.Range(0, 13), Mathf.Round(Random.Range(0, 100)) / 100, Mathf.Round(Random.Range(0, 100)) / 100, 
                    Random.Range(0, 13), Mathf.Round(Random.Range(0, 100)) / 100, Mathf.Round(Random.Range(0, 100)) / 100, 
                    Random.Range(0, 13), Mathf.Round(Random.Range(0, 100)) / 100, Mathf.Round(Random.Range(0, 100)) / 100);

                GetColor(Random.Range(0, 13), Mathf.Round(Random.Range(0, 100)) / 100, Mathf.Round(Random.Range(0, 100)) / 100, 
                    Random.Range(0, 13), Mathf.Round(Random.Range(0, 100)) / 100, Mathf.Round(Random.Range(0, 100)) / 100, 
                    Random.Range(0, 13), Mathf.Round(Random.Range(0, 100)) / 100, Mathf.Round(Random.Range(0, 100)) / 100);
            }
        }
    }

    [PunRPC]
    public void SetColor(int col, float metal, float smooth, int col0, float metal0, float smooth0, int col1, float metal1, float smooth1)
    {
        GetColor(col, metal, smooth, col0, metal0, smooth0, col1, metal1, smooth1);
    }

    public void GetColor(int col, float metal, float smooth, int col0, float metal0, float smooth0, int col1, float metal1, float smooth1) 
    {
        GetComponent<SkinnedMeshRenderer>().materials[0].color = material[col].color;
        GetComponent<SkinnedMeshRenderer>().materials[0].SetFloat("_Metallic", metal);
        GetComponent<SkinnedMeshRenderer>().materials[0].SetFloat("_Glossiness", smooth);

        GetComponent<SkinnedMeshRenderer>().materials[1].color = material[col0].color;
        GetComponent<SkinnedMeshRenderer>().materials[1].SetFloat("_Metallic", metal0);
        GetComponent<SkinnedMeshRenderer>().materials[1].SetFloat("_Glossiness", smooth0);

        GetComponent<SkinnedMeshRenderer>().materials[2].color = material[col1].color;
        GetComponent<SkinnedMeshRenderer>().materials[2].SetFloat("_Metallic", metal1);
        GetComponent<SkinnedMeshRenderer>().materials[2].SetFloat("_Glossiness", smooth1);
    }
}
