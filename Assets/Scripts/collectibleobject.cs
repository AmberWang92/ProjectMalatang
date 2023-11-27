using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string itemName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

            if (playerInventory != null)
            {
                Debug.Log("Collecting item: " + itemName);

            
                playerInventory.AddItem(itemName);

               
                if (playerInventory.HasItem(itemName))
                {
                    Debug.Log("Item successfully added to the inventory: " + itemName);
                }
                else
                {
                    Debug.LogError("Failed to add item to the inventory: " + itemName);
                }

              
              
                Destroy(gameObject);
            }
        }
    }
}
