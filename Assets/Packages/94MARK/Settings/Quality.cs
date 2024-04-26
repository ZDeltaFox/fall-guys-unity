using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quality : MonoBehaviour
{
    public TMP_Dropdown Calidad;

    public int Ajustes;

    void Start()
    {
        Ajustes = PlayerPrefs.GetInt("AjustesDeCalidad", 3);
        Calidad.value = Ajustes;
        Seleccionar();
    }

    public void Seleccionar()
    {
        QualitySettings.SetQualityLevel(Calidad.value);
        PlayerPrefs.SetInt("AjustesDeCalidad", Calidad.value);
        Ajustes = Calidad.value;
    }
}
