using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
