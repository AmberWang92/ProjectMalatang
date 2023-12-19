using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleFood : MonoBehaviour
{
    protected AudioSource pickupSound;

    protected virtual void Awake()
    {
        pickupSound = GetComponent<AudioSource>();
    }

    protected virtual void Collect()
    {

        pickupSound.PlayOneShot(pickupSound.clip);

        StartCoroutine(DeactivateAfterSound());
    }

    private IEnumerator DeactivateAfterSound()
    {
        
        yield return new WaitForSeconds(0.2f);
        
        gameObject.SetActive(false);
    }
    
    }
    


