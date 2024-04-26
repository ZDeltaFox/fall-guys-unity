using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customize : MonoBehaviour
{
    public float vel;
    public float maxPos;
    public int menu;
    public GameObject cam;
    public GameObject[] menuObj;

    public void ChangeMenu(int btnID)
    {
        menu = btnID;
    }

    void Update()
    {
        if (menu == 1)
        {
            if (cam.transform.position.x >= -maxPos)
            {
                cam.transform.position -= new Vector3(vel / 10, 0, 0);
            }

            menuObj[0].SetActive(false);
            menuObj[1].SetActive(true);
        }

        if (menu == 0)
        {
            if (cam.transform.position.x <= 0)
            {
                cam.transform.position += new Vector3(vel / 10, 0, 0);
            }

            menuObj[1].SetActive(false);
            menuObj[0].SetActive(true);
        }
    }
}
