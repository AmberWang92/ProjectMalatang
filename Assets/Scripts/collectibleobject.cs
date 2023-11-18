using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    void Collect()
    {
       
        counteringridients ingredientCounter = counteringridients.instance;

        if (ingredientCounter != null)
        {
            ingredientCounter.IncreaseIngr(1); 
        }

        Destroy(gameObject);
    }
}
