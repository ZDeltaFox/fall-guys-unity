using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadingGame : MonoBehaviour
{
    [Header ("Porcentage")]
    public TMP_Text LoadPorcentage;
    int porcentage;
    int resto;
    int complete = 100;
    public int multiplicar;
    public int dividir;

    [Header ("Texto")]
    float maxTime = 1f;
    public float timer;
    public TMP_Text LoadingText;
    public string LoadingQ;
    public string LoadingW;
    public string LoadingE;
    public string LoadingR;

    [Header ("Error")]
    public GameObject ErrorPrefab;
    public float rTime;
    public float loadMaxTime;
    public float crashTimer;
    public bool crashed = false;

    void Start()
    {
        crashed = false;
    }

    void Update()
    {
        if (!crashed)
        {
            resto++;
            timer += Time.deltaTime;
            rTime += Time.deltaTime;

            if (multiplicar >= 2)
            {
                porcentage = resto * multiplicar;
            }

            else
            {
                porcentage = resto / dividir;
            }


            porcentage = resto / dividir;
            if (porcentage <= 99){LoadPorcentage.text = porcentage.ToString("0") + "%";}
            if (porcentage >= 110){LoadPorcentage.text = complete.ToString("0") + "%";}
            if (porcentage >= 120){SceneManager.LoadScene("MainMenu");}

            if (timer >= maxTime)
            {
                if (timer <= maxTime * 2)
                {
                    LoadingText.text = LoadingW;
                }

                if (timer <= maxTime * 3)
                {
                    if (timer >= maxTime * 2)
                    {
                        LoadingText.text = LoadingE;
                    }
                }

                if (timer >= maxTime * 3)
                {
                    if (timer <= maxTime * 4)
                    {
                        LoadingText.text = LoadingR;
                    }
                }
                        
                if (timer >= maxTime * 4)
                {
                    timer = 0f;
                }
            }

            else
            {
                LoadingText.text = LoadingQ;
            }
        }

        else
        {
            Error.stError = "<size=72>El juego ha tardado mucho en //responder, cerrando en " 
            + (Mathf.Round(crashTimer));
            crashTimer -= Time.deltaTime;
        }

        if (rTime >= loadMaxTime)
        {
            rTime = 0;
            Crash();
        }

        if (crashTimer <= 0)
        {
            Application.Quit();
        }
    }

    void Crash()
    {
        Instantiate(ErrorPrefab);
        crashed = true;
    }
}
