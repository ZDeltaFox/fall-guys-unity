using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPoints : MonoBehaviour
{
    [Range (0, 20)]
    public int points;
    public static int _points;

    void Start()
    {
        
    }

    void Update()
    {
        _points = points;
    }
}
