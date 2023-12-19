using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectApple : CollectibleFood
{
    private void OnTriggerEnter(Collider other)
    {
        base.Collect();
        CollectibleControl.appleCount += 1;
    }
}

