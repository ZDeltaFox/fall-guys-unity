using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent (typeof (GameObject))]

public class FinishedCourse : MonoBehaviour
{
    public GameObject colliderObject;
    //void Start()
    //{
        //thisObject = gameObject;
    //}

    float timer;

    void Update()
    {
        if (CharacterControls._IsQualified)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                colliderObject.SetActive(true);
            }
        }
    }
}
