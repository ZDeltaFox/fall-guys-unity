using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadingLobby : MonoBehaviour
{
    float maxTime = 1f;
    float timer;
    public TMP_Text LoadingText;
    public string LoadingQ;
    public string LoadingW;
    public string LoadingE;
    public string LoadingR;

    void Update()
    {
        timer += Time.deltaTime;

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
}
