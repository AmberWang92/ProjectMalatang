using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFood : MonoBehaviour
{
    public AudioSource foodFX;

    private void OnTriggerEnter(Collider other)
    {
        foodFX.Play();
        CollectibleControl.appleCount += 1;
        this.gameObject.SetActive(false);
    }
}
