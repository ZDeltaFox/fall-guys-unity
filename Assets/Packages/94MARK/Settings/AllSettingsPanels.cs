using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSettingsPanels : MonoBehaviour
{
    public int currentPanel;
    public GameObject[] panels;
    public GameObject minusBtn;
    public GameObject plusBtn;

    void Update()
    {
        if (currentPanel == 0)
        {
            panels[0].SetActive(true);
            panels[1].SetActive(false);
            panels[2].SetActive(false);
            //panels[3].SetActive(false);
            minusBtn.SetActive(false);
            plusBtn.SetActive(true);
        }

        if (currentPanel == 1)
        {
            panels[1].SetActive(true);
            panels[0].SetActive(false);
            panels[2].SetActive(false);
            //panels[3].SetActive(false);
            minusBtn.SetActive(true);
            plusBtn.SetActive(true);
        }

        if (currentPanel == 3)
        {
            panels[2].SetActive(true);
            panels[0].SetActive(false);
            panels[1].SetActive(false);
            //panels[3].SetActive(false);
            minusBtn.SetActive(true);
            plusBtn.SetActive(true);
        }

        if (currentPanel == 2)
        {
            panels[2].SetActive(true);
            panels[0].SetActive(false);
            panels[1].SetActive(false);
            //panels[2].SetActive(false);
            minusBtn.SetActive(true);
            plusBtn.SetActive(false);
        }
    }

    public void plus() 
    {
        if (currentPanel <= panels.Length - 1.5)
        {
            currentPanel++;
        }
    }

    public void minus()
    {
        if (currentPanel >= 0.5)
        {
            currentPanel--;
        }
    }
}
