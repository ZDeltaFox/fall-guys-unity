using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCam : MonoBehaviour
{
    public float Number;

    void Update()
    {
        if (Number != LobbyNetworkManager.MyPlayerNumberCounter)
        {
            Destroy(gameObject);
        }
    }
}
