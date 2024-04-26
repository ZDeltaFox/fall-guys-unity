using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Error : MonoBehaviour
{
    [Header ("Error")]
    public static string stError;
    public string sError;

    [Header ("Tiempo")]
    public float timer;
    public float maxTime;

    public TMP_Text ErrorText;

    void Update()
    {
        sError = stError;

        if (timer >= maxTime) 
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;

        ErrorText.text = sError;
    }
}
