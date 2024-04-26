using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamSkybox : MonoBehaviour
{
    private Camera cam;
    private Skybox skybox;
    void Start()
    {
        cam = GetComponent<Camera>();
        skybox = GetComponent<Skybox>();
    }

    // Update is called once per frame
    void Update()
    {
        skybox.material = GetComponent<ColorFallGuys>().Skybox[PlayerPrefs.GetInt("SkyBox")];
    }
}
