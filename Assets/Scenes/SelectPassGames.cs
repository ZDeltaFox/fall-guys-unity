using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPassGames : MonoBehaviour
{
    public float timeSpawn;
    public GameObject[] games1;
    public GameObject[] games2;
    public GameObject[] games3;
    public int[] games;
    public int currentGame;
    public int lastGame;
    public float timeToChange;
    public float timer;

    void Start()
    {
        games[0] = games1.Length;
        games[1] = games2.Length;
        games[2] = games3.Length;
        StartCoroutine(SpawnObj());
    }

    IEnumerator SpawnObj()
    {
        if (Rounds._thisRound == 1)
        {
            currentGame = Random.Range(1, games[0]);
            games1[currentGame - 1].transform.position = new Vector3(25, 0, 0);
        }

        if (Rounds._thisRound == 2)
        {
            currentGame = Random.Range(1, games[0]);
            games2[currentGame - 1].transform.position = new Vector3(25, 0, 0);
        }

        if (Rounds._thisRound == 3)
        {
            currentGame = Random.Range(1, games[2]);
            games3[currentGame - 1].transform.position = new Vector3(25, 0, 0);
        }
        yield return new WaitForSeconds(timeSpawn);
        lastGame = currentGame;
        StartCoroutine(SpawnObj());
    }
}
