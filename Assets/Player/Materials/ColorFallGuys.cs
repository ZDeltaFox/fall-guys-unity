using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;

public class ColorFallGuys : MonoBehaviour
{
    [Header ("Materials")]
    public Material[] material;
    public static int mesh;
    public static int[] colorNumber = new int[3];
    public static float[] metallic = new float[3];
    public static float[] smoothness = new float[3];

    [Header ("Skybox")]
    public Material[] Skybox;
    public int SkyboxNumber;
    public TMP_Text skyboxTXT;
    public string[] skyboxNames;
    //public Camera cam;

    [Header ("Global")]
    public TMP_Text[] texts;
    public string[] strings;

    public Slider[] sliders;

    void Start()
    {
        texts[0].text = "Body";
        mesh = 0;
    }

    void Update()
    {
        if (mesh == 0)
        {
            sliders[0].value = PlayerPrefs.GetInt("color0");
            sliders[1].value = PlayerPrefs.GetFloat("metal0");
            sliders[2].value = PlayerPrefs.GetFloat("Smooth0");
        }

        if (mesh == 1)
        {
            sliders[0].value = PlayerPrefs.GetInt("color1");
            sliders[1].value = PlayerPrefs.GetFloat("metal1");
            sliders[2].value = PlayerPrefs.GetFloat("Smooth1");
        }

        if (mesh == 2)
        {
            sliders[0].value = PlayerPrefs.GetInt("color2");
            sliders[1].value = PlayerPrefs.GetFloat("metal2");
            sliders[2].value = PlayerPrefs.GetFloat("Smooth2");
        }

        sliders[3].value = PlayerPrefs.GetInt("SkyBox");
        skyboxTXT.text = "Skybox: " + skyboxNames[SkyboxNumber];
        RenderSettings.skybox = Skybox[SkyboxNumber];

        texts[1].text = strings[PlayerPrefs.GetInt("color" + mesh.ToString())];
        texts[2].text = "Metallic: " + Mathf.Round(PlayerPrefs.GetFloat("metal" + mesh.ToString()) * 100) + "%";
        texts[3].text = "Smoothness: " + Mathf.Round(PlayerPrefs.GetFloat("Smooth" + mesh.ToString()) * 100) + "%";

        /*// Obtener la cámara principal
        Camera mainCamera = Camera.main;

        // Obtener el componente Skybox de la cámara
        Skybox skybox = mainCamera.GetComponent<Skybox>();

        // Asignar el nuevo material al componente Skybox
        skybox.material = newSkyboxMaterial;*/
    }

    public void MeshSlider(float value)
    {
        mesh = (int)value;

        if (value == 0) {texts[0].text = "Body";}
        if (value == 1) {texts[0].text = "Ears";}
        if (value == 2) {texts[0].text = "Eyes";}
    }

    public void ColorSlider(float value)
    {
        colorNumber[mesh] = (int)value;
        PlayerPrefs.SetInt("color" + mesh.ToString(), (int)value);
    }

    public void MetalSlider(float value)
    {
        metallic[mesh] = value;
        PlayerPrefs.SetFloat("metal" + mesh.ToString(), value);
    }

    public void SmoothnessSlider(float value)
    {
        smoothness[mesh] = value;
        PlayerPrefs.SetFloat("Smooth" + mesh.ToString(), value);
    }

    public void SkyboxSlider(float value)
    {
        SkyboxNumber = (int)value;
        PlayerPrefs.SetInt("SkyBox", SkyboxNumber);
    }
}
