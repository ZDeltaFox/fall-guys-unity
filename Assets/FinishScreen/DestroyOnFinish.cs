using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFinish : MonoBehaviour
{
    public bool confirmDestroy;

    void Update()
    {
        if (confirmDestroy)
        {
            if (Qualified.IsChangingRoom)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
