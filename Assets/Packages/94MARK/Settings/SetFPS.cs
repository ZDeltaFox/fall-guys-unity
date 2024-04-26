using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetFPS : MonoBehaviour
{
    public int FPS;

    public string Limit;

    public TMP_Text FPSText;

    //FPS Controller
    public Button fpsMinus;
    public Button fpsPlus;

    void Start()
    {
        
        if (PlayerPrefs.HasKey("fpsvalue")) {FPS = PlayerPrefs.GetInt("fpsvalue", 0);}
        else {Application.targetFrameRate = 60;}
        Application.targetFrameRate = FPS;
    }

    void Update()
    {
        if (FPS >= 145) {Application.targetFrameRate = 144;}

        PlayerPrefs.SetInt("fpsvalue", FPS);

        FPS = Application.targetFrameRate;

        if (FPS == 0) {Application.targetFrameRate = 24;}

        if (FPS >= 0) {FPSText.text = FPS.ToString("00") + " FPS";}
        else {FPSText.text = Limit;}

        if (FPS == 24) {fpsMinus.interactable = false;}
        else {fpsMinus.interactable = true;}

        if (FPS == -1) {fpsPlus.interactable = false;}
        else {fpsPlus.interactable = true;}
    }

    public void FPSMinus()
    {
        if (FPS == -1) {Application.targetFrameRate = 144;}

        if (FPS == 144) {Application.targetFrameRate = 120;}
        
        if (FPS == 120) {Application.targetFrameRate = 90;}

        if (FPS == 90) {Application.targetFrameRate = 60;}

        if (FPS == 60) {Application.targetFrameRate = 30;}

        if (FPS == 30) {Application.targetFrameRate = 24;}
    }

    public void FPSPlus()
    {
        if (FPS == 144) {Application.targetFrameRate = -1;}

        if (FPS == 120) {Application.targetFrameRate = 144;}
        
        if (FPS == 90) {Application.targetFrameRate = 120;}

        if (FPS == 60) {Application.targetFrameRate = 90;}

        if (FPS == 30) {Application.targetFrameRate = 60;}

        if (FPS == 24) {Application.targetFrameRate = 30;}
    }
}