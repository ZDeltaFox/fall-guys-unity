using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ImpostorSelectorLobby : MonoBehaviourPunCallbacks
{
    [Header ("Number")]
    public float Number;

    [Header ("Time")]
    public float timer;
    public float Players;

    [Header ("Players")]
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;
    public GameObject player6;
    public GameObject player7;
    public GameObject player8;
    public GameObject player9;
    public GameObject player10;

    float setNumber1;
    float setNumber2;
    float setNumber3;
    float setNumber4;
    float setNumber5;
    float setNumber6;
    float setNumber7;
    float setNumber8;
    float setNumber9;
    float setNumber10;

    public float NumberPlayer1;
    public float NumberPlayer2;
    public float NumberPlayer3;
    public float NumberPlayer4;
    public float NumberPlayer5;
    public float NumberPlayer6;
    public float NumberPlayer7;
    public float NumberPlayer8;
    public float NumberPlayer9;
    public float NumberPlayer10;

    public void Sort()
    {
        setNumber1 = 0;
        setNumber2 = 0;
        setNumber3 = 0;
        setNumber4 = 0;
        setNumber5 = 0;
        setNumber6 = 0;
        setNumber7 = 0;
        setNumber8 = 0;
        setNumber9 = 0;
        setNumber10 = 0;
    }

    void Update()
    {
        StartCoroutine(RepeatedNumbers());
#region MoveBlocks
        if (LobbyNetworkManager.MyPlayerNumberCounter == 1)
        {
            player1.transform.position = new Vector3(setNumber1, 1000, 0);
            player2.transform.position = new Vector3(setNumber2, 1000, 1);
            player3.transform.position = new Vector3(setNumber3, 1000, 2);
            player4.transform.position = new Vector3(setNumber4, 1000, 3);
            player5.transform.position = new Vector3(setNumber5, 1000, 4);
            player6.transform.position = new Vector3(setNumber6, 1000, 5);
            player7.transform.position = new Vector3(setNumber7, 1000, 6);
            player8.transform.position = new Vector3(setNumber8, 1000, 7);
            player9.transform.position = new Vector3(setNumber9, 1000, 8);
            player10.transform.position = new Vector3(setNumber10, 1000, 9);
        }

        Number = LobbyNetworkManager.PNC;
#endregion
        timer += Time.deltaTime;

        if (timer >= 0.2)
        {
            Players = LobbyNetworkManager.SPlayerCounter;
            timer = 0;
        }

        else
        {
            Players = 10;
        }

        //if (Players != LobbyNetworkManager.SPlayerCounter)
        //{
            //setNumber1 = 0;
            //setNumber2 = 0;
            //setNumber3 = 0;
            //setNumber4 = 0;
            //setNumber5 = 0;
            //setNumber6 = 0;
            //setNumber7 = 0;
            //setNumber8 = 0;
            //setNumber9 = 0;
            //setNumber10 = 0;
        //}

#region Change Number With Block Position
        NumberPlayer1 = Mathf.Round(player1.transform.position.x);
        NumberPlayer2 = Mathf.Round(player2.transform.position.x);
        NumberPlayer3 = Mathf.Round(player3.transform.position.x);
        NumberPlayer4 = Mathf.Round(player4.transform.position.x);
        NumberPlayer5 = Mathf.Round(player5.transform.position.x);
        NumberPlayer6 = Mathf.Round(player6.transform.position.x);
        NumberPlayer7 = Mathf.Round(player7.transform.position.x);
        NumberPlayer8 = Mathf.Round(player8.transform.position.x);
        NumberPlayer9 = Mathf.Round(player9.transform.position.x);
        NumberPlayer10 = Mathf.Round(player10.transform.position.x);

        if (LobbyNetworkManager.MyPlayerNumberCounter == 1) {LobbyNetworkManager.PNC = NumberPlayer1;}
        if (LobbyNetworkManager.MyPlayerNumberCounter == 2) {LobbyNetworkManager.PNC = NumberPlayer2;}
        if (LobbyNetworkManager.MyPlayerNumberCounter == 3) {LobbyNetworkManager.PNC = NumberPlayer3;}
        if (LobbyNetworkManager.MyPlayerNumberCounter == 4) {LobbyNetworkManager.PNC = NumberPlayer4;}
        if (LobbyNetworkManager.MyPlayerNumberCounter == 5) {LobbyNetworkManager.PNC = NumberPlayer5;}
        if (LobbyNetworkManager.MyPlayerNumberCounter == 6) {LobbyNetworkManager.PNC = NumberPlayer6;}
        if (LobbyNetworkManager.MyPlayerNumberCounter == 7) {LobbyNetworkManager.PNC = NumberPlayer7;}
        if (LobbyNetworkManager.MyPlayerNumberCounter == 8) {LobbyNetworkManager.PNC = NumberPlayer8;}
        if (LobbyNetworkManager.MyPlayerNumberCounter == 9) {LobbyNetworkManager.PNC = NumberPlayer9;}
        if (LobbyNetworkManager.MyPlayerNumberCounter == 10) {LobbyNetworkManager.PNC = NumberPlayer10;}
#endregion
    }

    void Start()
    {
        //if (setNumber == -1)
        //{
            //material.Number = Random.NumberHSV();
        //}

        //setNumber = PlayerPrefs.GetFloat("actualNumber");

        StartCoroutine(RepeatedNumbers());
    }

    public IEnumerator RepeatedNumbers()
    {
        if (LobbyNetworkManager.MyPlayerNumberCounter == 1)
        {
#region SetNumber
        if (setNumber1 == 0)
        {
            if (Players >= 0.5) {setNumber1 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
            if (Players >= 1.5) {setNumber2 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
            if (Players >= 2.5) {setNumber3 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
            if (Players >= 3.5) {setNumber4 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
            if (Players >= 4.5) {setNumber5 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
            if (Players >= 5.5) {setNumber6 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
            if (Players >= 6.5) {setNumber7 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
            if (Players >= 7.5) {setNumber8 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
            if (Players >= 8.5) {setNumber9 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
            if (Players >= 9.5) {setNumber10 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
        }
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetNumber2
        if (setNumber2 == setNumber1 && setNumber2 != 0) {setNumber2 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetNumber3
        if (setNumber3 == setNumber1 && setNumber3 != 0) {setNumber3 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber3 == setNumber2 && setNumber3 != 0) {setNumber3 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetNumber4
        if (setNumber4 == setNumber1 && setNumber4 != 0) {setNumber4 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber4 == setNumber2 && setNumber4 != 0) {setNumber4 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber4 == setNumber3 && setNumber4 != 0) {setNumber4 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetNumber5
        if (setNumber5 == setNumber1 && setNumber5 != 0) {setNumber5 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber5 == setNumber2 && setNumber5 != 0) {setNumber5 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber5 == setNumber3 && setNumber5 != 0) {setNumber5 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber5 == setNumber4 && setNumber5 != 0) {setNumber5 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetNumber6
        if (setNumber6 == setNumber1 && setNumber6 != 0) {setNumber6 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber6 == setNumber2 && setNumber6 != 0) {setNumber6 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber6 == setNumber3 && setNumber6 != 0) {setNumber6 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber6 == setNumber4 && setNumber6 != 0) {setNumber6 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber6 == setNumber5 && setNumber6 != 0) {setNumber6 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetNumber7
        if (setNumber7 == setNumber1 && setNumber7 != 0) {setNumber7 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber7 == setNumber2 && setNumber7 != 0) {setNumber7 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber7 == setNumber3 && setNumber7 != 0) {setNumber7 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber7 == setNumber4 && setNumber7 != 0) {setNumber7 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber7 == setNumber5 && setNumber7 != 0) {setNumber7 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber7 == setNumber6 && setNumber7 != 0) {setNumber7 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber7 == setNumber8 && setNumber7 != 0) {setNumber7 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber7 == setNumber9 && setNumber7 != 0) {setNumber7 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber7 == setNumber10 && setNumber7 != 0) {setNumber7 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetNumber8
        if (setNumber8 == setNumber1 && setNumber8 != 0) {setNumber8 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber8 == setNumber2 && setNumber8 != 0) {setNumber8 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber8 == setNumber3 && setNumber8 != 0) {setNumber8 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber8 == setNumber4 && setNumber8 != 0) {setNumber8 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber8 == setNumber5 && setNumber8 != 0) {setNumber8 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber8 == setNumber6 && setNumber8 != 0) {setNumber8 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber8 == setNumber7 && setNumber8 != 0) {setNumber8 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetNumber9
        if (setNumber9 == setNumber1 && setNumber9 != 0) {setNumber9 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber9 == setNumber2 && setNumber9 != 0) {setNumber9 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber9 == setNumber3 && setNumber9 != 0) {setNumber9 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber9 == setNumber4 && setNumber9 != 0) {setNumber9 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber9 == setNumber5 && setNumber9 != 0) {setNumber9 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber9 == setNumber6 && setNumber9 != 0) {setNumber9 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber9 == setNumber7 && setNumber9 != 0) {setNumber9 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber9 == setNumber8 && setNumber9 != 0) {setNumber9 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetNumber10
        if (setNumber10 == setNumber1 && setNumber10 != 0) {setNumber10 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber10 == setNumber2 && setNumber10 != 0) {setNumber10 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber10 == setNumber3 && setNumber10 != 0) {setNumber10 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber10 == setNumber4 && setNumber10 != 0) {setNumber10 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber10 == setNumber5 && setNumber10 != 0) {setNumber10 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber10 == setNumber6 && setNumber10 != 0) {setNumber10 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber10 == setNumber7 && setNumber10 != 0) {setNumber10 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber10 == setNumber8 && setNumber10 != 0) {setNumber10 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}

        if (setNumber10 == setNumber9 && setNumber10 != 0) {setNumber10 = Mathf.Round(Random.Range(1, LobbyNetworkManager.SPlayerCounter));}
#endregion
        }
    }
}

