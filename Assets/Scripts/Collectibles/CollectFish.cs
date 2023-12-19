using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFish : CollectibleFood
{
    private void OnTriggerEnter(Collider other)
    {
        base.Collect();
        CollectibleControl.fishCount += 1;

    }
}
