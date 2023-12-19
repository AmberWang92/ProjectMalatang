using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCarrot : CollectibleFood
{
    private void OnTriggerEnter(Collider other)
    {
        base.Collect();
        CollectibleControl.carrotCount += 1;

    }
}
