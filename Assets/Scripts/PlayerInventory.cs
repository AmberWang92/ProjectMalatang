using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Making collectedItems public
    public List<string> collectedItems = new List<string>();

    public ItemSlot[] itemSlot;

    // ... (other existing code)

    public List<string> GetCollectedItems()
    {
        List<string> collectedItemsList = new List<string>(collectedItems);
        Debug.Log("Collected Items: " + string.Join(", ", collectedItemsList));
        return collectedItemsList;
    }


    public void AddItem(string itemName)
    {
        Debug.Log("itemSlot Length: " + itemSlot.Length);

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName);
                collectedItems.Add(itemName); // Adding item to collectedItems
                counteringridients.instance.IncreaseIngr(1);
                return;
            }
        }
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
