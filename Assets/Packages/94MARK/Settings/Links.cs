using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Links : MonoBehaviour
{
    public void LinkButtons(string Link)
    {
        Application.OpenURL(Link);
    }
}

