using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivate : MonoBehaviour
{
    public bool isActive;
    void Start()
    {
        StartCoroutine(StartIE());
    }

    IEnumerator StartIE()
    {
        if (isActive)
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }
    }
}
