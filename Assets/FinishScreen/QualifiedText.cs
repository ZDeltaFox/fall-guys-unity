using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QualifiedText : MonoBehaviour
{   
    public TMP_Text txt;

    //void Start() {txt = GetComponent<TMP_Text>();}

    void Update()
    {
        if (CharacterControls._IsQualified) {txt.text = "Qualified";}
        else {txt.text = "Not qualified";}
    }
}
