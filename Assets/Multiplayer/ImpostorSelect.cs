using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class ImpostorSelect : Photon.Pun.MonoBehaviourPun
{
    [SerializeField] private GameObject _impostorWindow;
    [SerializeField] private Text _impostorText;

    public void Initialize()
    {
        StartCoroutine(PickImpostor());
    }

    private IEnumerator PickImpostor()
    {
        GameObject[] players;
        List<int> playerIndex = new List<int>();
        int tries = 0;
        int impostorNumber = 0;
        int impostorNumberFinal = 0;

        //Get all the players in the game
        do
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            tries++;
            yield return new WaitForSeconds(0.25f);
        }

        while ((players.Length < PhotonNetwork.PlayerList.Length) && (tries < 5));

        //Initialize the playerIndex list
        for (int i = 0; i < players.Length; i++) {playerIndex.Add(i);}

        //Based on the player number, pick up how many impostors to have
        //if (players.Length < 5) {impostorNumber = 1;}
        //else {impostorNumber = 2;}

        //Can be simplified
        impostorNumber = players.Length < 5 ? 1 : 2;
        impostorNumberFinal = impostorNumber;

        while (impostorNumber > 0)
        {
            int pickedImpostorIndex = playerIndex[Random.Range(0, playerIndex.Count)];
            playerIndex.Remove(pickedImpostorIndex);

            PhotonView pv = players[pickedImpostorIndex].GetComponent<PhotonView>();
            pv.RPC("SetImpostor", RpcTarget.All);

            impostorNumber--;

            //ImpostorE1 = pickedImpostorIndex;
        }

        photonView.RPC("ImpostorPicked", RpcTarget.All, impostorNumberFinal);

        //My method



        //1 Impostor
        //if (LobbyNetworkManager.SPlayerCounter != 10)
        //{
            //Impostor1 = (Random.Range(0, LobbyNetworkManager.SPlayerCounter));
            //Impostor2 = -1;
        //}

        //else
        //{
            //Impostor1 = (Random.Range(0, LobbyNetworkManager.SPlayerCounter));
            //yield return new WaitForSeconds(0.25f);
            //Impostor2 = (Random.Range(0, LobbyNetworkManager.SPlayerCounter));
        //}

        //yield return new WaitForSeconds(0.25f);

        //PhotonView pvi = players[pickedImpostorIndex].GetComponent<PhotonView>();
        //pvi.RPC("SetImpostor", RpcTarget.All);
        //pvi.RPC("ImpostorPicked", RpcTarget.All, impostorNumberFinal);
        yield return new WaitForSeconds(0.5f);
        I1 = tries;
        I2 = impostorNumber;
        I2 = impostorNumberFinal;
    }

    [PunRPC]

    void Update()
    {
        if (LobbyNetworkManager.SPlayerCounter != 10) {_impostorText.text = "Hay 1 impostor entre nosotros";} 
        else {_impostorText.text = "Hay 2 impostores entre nosotros";}
        if (timer >= timeDel) {_impostorWindow.SetActive(false);}
        else {_impostorWindow.SetActive(true);}
        timer += Time.deltaTime;
    }

    public float timer;
    float timeDel = 2f;

    public float I1;
    public float I2;
    public float I3;
    public float I4;
}
