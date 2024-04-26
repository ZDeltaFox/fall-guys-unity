using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectImpostor : MonoBehaviour
{
    [Header ("Impostor Select")]

    public GameObject I1;
    public GameObject I2;

    [Header ("Set Impostor")]
    public float AllI1;
    public float AllI2;
    public static float AllIS1;
    public static float AllIS2;

    void Update()
    {
        AllI1 = I1.transform.position.x;
        AllI2 = I2.transform.position.x;

        AllIS1 = AllI1;
        AllIS2 = AllI2;
    }
}
