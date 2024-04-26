using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxLighting : MonoBehaviour
{
    public Material[] skyboxes;
    public float[] lightIntensities;
    public Vector3[] lightDirections;
    public Color[] lightColors;

    private Light mainLight;
    private Material currentSkybox;

    void Start()
    {
        mainLight = GetComponent<Light>();
        currentSkybox = RenderSettings.skybox;
        UpdateLighting(currentSkybox);
    }

    void Update()
    {
        if (RenderSettings.skybox != currentSkybox)
        {
            currentSkybox = RenderSettings.skybox;
            UpdateLighting(currentSkybox);
        }
    }

    void UpdateLighting(Material skybox)
    {
        int index = System.Array.IndexOf(skyboxes, skybox);

        if (index >= 0)
        {
            mainLight.intensity = lightIntensities[index];
            //mainLight.transform.rotation = Quaternion.LookRotation(lightDirections[index]);
            mainLight.transform.rotation = Quaternion.Euler(lightDirections[index]);
            mainLight.color = lightColors[index];
        }
    }
}