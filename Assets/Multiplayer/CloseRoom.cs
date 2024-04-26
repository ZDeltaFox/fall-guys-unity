using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRoom : MonoBehaviour
{
    float timer;

    public float timeToClose;
    public static float sTimeToClose;

    public float maxTime;
    public static float sMaxTime;

    void Update()
    {
        if (LobbyNetworkManager.MyPlayerNumberCounter == 1)
        {
            timer += Time.deltaTime;
            gameObject.transform.position = new Vector3(timer, 1000, 0);
        }

        timeToClose = gameObject.transform.position.x;
        sTimeToClose = timeToClose; 

        sMaxTime = maxTime;
    }

    void Start()
    {
        timer = 0;
        gameObject.transform.position = new Vector3(0, 1000, 0);
    }
}
