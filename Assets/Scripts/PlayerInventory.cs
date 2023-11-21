using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    ///public Slot[] slots; // Array of Slot objects representing your slots
    //public GameObject[] items; // Array of collected item GameObjects
    private List<string> collectedItems = new List<string>();

    //public GameObject[] slots;

    public void AddItem(string itemName)
    {
        // Update our model of collected items
        // collectedItems.Add(itemName);


        // Update the UI to show collected items
        counteringridients.instance.IncreaseIngr(1);
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
