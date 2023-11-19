using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string itemName;
    public GameObject collectEffect;
    public int scoreValue = 1; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone"); 
            Collect(other.GetComponent<PlayerInventory>());
        }
    }

    void Collect(PlayerInventory playerInventory)
    {
        if (playerInventory != null)
        {
            Debug.Log("Collecting item: " + itemName);
            playerInventory.AddItem(itemName);  // Pass the itemName string instead of 'this'

            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }


}

