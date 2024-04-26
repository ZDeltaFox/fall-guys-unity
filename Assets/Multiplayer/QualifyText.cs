using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QualifyText : MonoBehaviour
{
    [Header ("Round Type")]
    public bool isSurvival;

    /*[Header ("Players")]
    [Range(1, 20)]
    public int players;*/

    [Header ("Text")]
    public TMP_Text qualifyText;

    void Update()
    {
        if (isSurvival)
        {
            qualifyText.text = Qualified._DeathPlayers.ToString("0") + " / " + Qualified._maxQualify[Rounds._thisRound].ToString("0");
        }

        else 
        {
            qualifyText.text = Qualified._Qualifieds.ToString("0") + " / " + Qualified._maxQualify[Rounds._thisRound].ToString("0");
        }
    }
}
