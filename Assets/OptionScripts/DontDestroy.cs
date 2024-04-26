using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public bool applyDontDestroyOnLoad;
    
    private static DontDestroy instance;

    private void Awake()
    {
        if (applyDontDestroyOnLoad)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
