using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float coins;
    public static float sCoins;

    public float gems;
    public static float sGems;

    void Start()
    {
        sCoins = PlayerPrefs.GetFloat("coins");

        sGems = PlayerPrefs.GetFloat("gems");
    }

    void Update()
    {
        if (coins != sCoins)
        {
            PlayerPrefs.SetFloat("coins", sCoins);
            coins = sCoins;
        }

        if (gems != sGems)
        {
            PlayerPrefs.SetFloat("gems", sGems);
            gems = sGems;
        }
    }
}
