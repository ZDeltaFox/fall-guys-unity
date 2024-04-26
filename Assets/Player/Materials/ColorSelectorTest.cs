using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelectorTest : MonoBehaviour
{
    public Material[] material;
    public int cN;
    public int cN1;
    public int cN2;

    void Update()
    {
        cN = PlayerPrefs.GetInt("color0");
        cN1 = PlayerPrefs.GetInt("color1");
        cN2 = PlayerPrefs.GetInt("color2");

        GetComponent<SkinnedMeshRenderer>().materials[0].color = material[cN].color;
        GetComponent<SkinnedMeshRenderer>().materials[0].SetFloat("_Metallic", PlayerPrefs.GetFloat("metal0"));
        GetComponent<SkinnedMeshRenderer>().materials[0].SetFloat("_Glossiness", PlayerPrefs.GetFloat("Smooth0"));

        GetComponent<SkinnedMeshRenderer>().materials[1].color = material[cN1].color;
        GetComponent<SkinnedMeshRenderer>().materials[1].SetFloat("_Metallic", PlayerPrefs.GetFloat("metal1"));
        GetComponent<SkinnedMeshRenderer>().materials[1].SetFloat("_Glossiness", PlayerPrefs.GetFloat("Smooth1"));

        GetComponent<SkinnedMeshRenderer>().materials[2].color = material[cN2].color;
        GetComponent<SkinnedMeshRenderer>().materials[2].SetFloat("_Metallic", PlayerPrefs.GetFloat("metal2"));
        GetComponent<SkinnedMeshRenderer>().materials[2].SetFloat("_Glossiness", PlayerPrefs.GetFloat("Smooth2"));
        //GetComponent<SkinnedMeshRenderer>().materials[2].SetFloat("_Smoothness", PlayerPrefs.GetFloat("Smooth2"));
    }
}
