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
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName);
                counteringridients.instance.IncreaseIngr(1);
                return;
            }
        }
        // Update our model of collected items
        // collectedItems.Add(itemName);
        // Update the UI to show collected items
    }

    public bool HasItem(string itemName)
    {
        return collectedItems.Contains(itemName);
    }

    public void RemoveItem(string itemName)
    {
        collectedItems.Remove(itemName);
        counteringridients.instance.DecreaseIngr(1);
    }
}
