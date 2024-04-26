using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public GameObject[] spawnPlayer;
    public static Vector3[] positions;
    int i;

    [Range (1, 3)]
    public int round;

    void Awake()
    {
        List<Vector3> posicionesLista = new List<Vector3>();

        posicionesLista.Add(spawnPlayer[0].transform.position);
        posicionesLista.Add(spawnPlayer[1].transform.position);
        posicionesLista.Add(spawnPlayer[2].transform.position);
        posicionesLista.Add(spawnPlayer[3].transform.position);
        posicionesLista.Add(spawnPlayer[4].transform.position);
        posicionesLista.Add(spawnPlayer[5].transform.position);
        posicionesLista.Add(spawnPlayer[6].transform.position);
        if (round != 3)
        posicionesLista.Add(spawnPlayer[7].transform.position);
        posicionesLista.Add(spawnPlayer[8].transform.position);
        posicionesLista.Add(spawnPlayer[9].transform.position);
        posicionesLista.Add(spawnPlayer[10].transform.position);
        posicionesLista.Add(spawnPlayer[11].transform.position);
        posicionesLista.Add(spawnPlayer[12].transform.position);
        posicionesLista.Add(spawnPlayer[13].transform.position);
        if (round == 1)
        {
            posicionesLista.Add(spawnPlayer[14].transform.position);
            posicionesLista.Add(spawnPlayer[15].transform.position);
            posicionesLista.Add(spawnPlayer[16].transform.position);
            posicionesLista.Add(spawnPlayer[17].transform.position);
            posicionesLista.Add(spawnPlayer[18].transform.position);
            posicionesLista.Add(spawnPlayer[19].transform.position);
        }

        positions = posicionesLista.ToArray();
    }
}
