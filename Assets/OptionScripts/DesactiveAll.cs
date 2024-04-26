using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesactiveAll : MonoBehaviour
{
    public bool applyDesactiveAll;

    public bool isInThisScene;
    public string[] blockedScenes;
    public GameObject[] objects;
    string sceneName;

    public int iObj;
    public int iScene;

    void Update()
    {
        if (applyDesactiveAll)
        {
            for (iScene = 0; iScene < blockedScenes.Length; iScene++)
            {
                if (SceneManager.GetActiveScene().name == blockedScenes[iScene])
                {
                    isInThisScene = true;
                }
            }

            if (sceneName != SceneManager.GetActiveScene().name)
            {
                isInThisScene = false;
                iObj = 0;
                iScene = 0;
                StartCoroutine(SetActive());
                sceneName = SceneManager.GetActiveScene().name;
            }
        }
    }

    IEnumerator SetActive()
    {
        yield return new WaitForSeconds(1f);
        if (isInThisScene)
        {
            for (iObj = 0; iObj < objects.Length; iObj++)
            {
                objects[iObj].SetActive(false);
                StartCoroutine(SetActive());
            }
        }

        else
        {
            //for (iObj = 0; iObj < objects.Length; iObj++)
            //{
                objects[1].SetActive(true);
            //}
        }
    }
}
