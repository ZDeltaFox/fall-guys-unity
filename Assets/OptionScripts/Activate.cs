using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public bool isActive;
    public GameObject[] Obj;
    void Start()
    {
        StartCoroutine(StartIE());
    }

    IEnumerator StartIE()
    {
        yield return new WaitForSeconds(0.001f);
        
        if (isActive)
        {
            for (int i = 0; i > Obj.Length; i++)
            {
                Obj[i - 1].SetActive(true);
                StartCoroutine(StartIE());
            }
        }
    }
}
