using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<string> collectedItems = new List<string>();

    public ItemSlot[] itemSlot;
    // [SerializeField] private InventoryManager inventoryManager;
    // void Start()
    // {
    //     inventoryManager = GameObject.Find("UI collected items").GetComponent<InventoryManager>();
    // }
    public void AddItem(string itemName)
    {
        Debug.Log("itemSlot Length: " + itemSlot.Length);

        for (int i = 0; i < itemSlot.Length; i++)
        {
            // We check if slot 'i' is available
            if (!itemSlot[i].isFull)
            {
                // Update our model of collected items
                collectedItems.Add(itemName);

                // Update information for our UI inventory panel
                itemSlot[i].AddItem(itemName);

                // Update UI counter
                counteringridients.instance.IncreaseIngr(1);
                return;
            }
        }

    }

    public bool HasItem(string itemName)
    {
        Debug.Log("collected items: " + collectedItems);
        return collectedItems.Contains(itemName);
    }

    public void RemoveItem(string itemName)
    {
        collectedItems.Remove(itemName);
        counteringridients.instance.DecreaseIngr(1);
    }
}
