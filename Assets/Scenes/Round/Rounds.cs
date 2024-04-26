using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Rounds : MonoBehaviour
{
    [Header ("Ronda Actual")]
    public static int _thisRound;
    public int thisRound;

    [Header ("Juegos")]
    public string[] firstRoundGames;
    public string[] secondRoundGames;
    public string[] lastRoundGames;

    void Start()
    {
        StartCoroutine(LoadScenes());
    }

    void Update()
    {
        thisRound = _thisRound;
    }

    IEnumerator LoadScenes()
    {
        if (PlayerID._ID == 1 || !PhotonNetwork.InRoom)
        {
            int round1 = firstRoundGames.Length;
            int round2 = secondRoundGames.Length;
            int round3 = lastRoundGames.Length;
            yield return new WaitForSeconds(5f);
            #region Load Scene
            if (thisRound == 1)
            {
                int i = Random.Range(1, round1 + 1);
                yield return new WaitForSeconds(0.1f);
                if (PhotonNetwork.InRoom) {PhotonNetwork.LoadLevel(firstRoundGames[i - 1]);}
                else {SceneManager.LoadScene(firstRoundGames[i - 1]);}
            }

            if (thisRound == 2)
            {
                int i = Random.Range(1, round2 + 1);
                yield return new WaitForSeconds(0.1f);
                if (PhotonNetwork.InRoom) {PhotonNetwork.LoadLevel(secondRoundGames[i - 1]);}
                else {SceneManager.LoadScene(secondRoundGames[i - 1]);}
            }

            if (thisRound == 3)
            {
                int i = Random.Range(1, round3 + 1);
                yield return new WaitForSeconds(0.1f);
                if (PhotonNetwork.InRoom) {PhotonNetwork.LoadLevel(lastRoundGames[i - 1]);}
                else {SceneManager.LoadScene(lastRoundGames[i - 1]);}
            }
            #endregion
        }
    }
}
