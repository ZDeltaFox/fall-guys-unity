using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveCam : MonoBehaviour
{
    public GameObject cam;

    void Start() {cam.SetActive(false);}

    void Update() {if (Qualified.IsChangingRoom) {cam.SetActive(true);}}
}
