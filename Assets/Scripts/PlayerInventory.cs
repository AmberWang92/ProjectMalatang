using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<string> collectedItems = new List<string>();

    public void AddItem(string itemName)
    {
        collectedItems.Add(itemName);
    }

    public bool HasItem(string itemName)
    {
        return collectedItems.Contains(itemName);
    }

    public void RemoveItem(string itemName)
    {
        collectedItems.Remove(itemName);
    }
}
