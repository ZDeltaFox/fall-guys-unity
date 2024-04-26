using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateLayer : MonoBehaviour
{
    public int l1;
    public int l2;
    
    void Start()
    {
        Physics.IgnoreLayerCollision(layer1: l1, layer2: l2, ignore: true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
