using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSBugSol : MonoBehaviour
{
    public string Min;
    public string Max;

    public TMP_Text MinT;
    public TMP_Text MinT1;
    public TMP_Text MaxT;
    public TMP_Text MaxT1;

    void Update()
    {
        MinT.text = Min;
        MinT1.text = Min;
        MaxT.text = Max;
        MaxT1.text = Max;
    }
}
