
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<string> collectedItems = new List<string>();

    public ItemSlot[] itemSlot;

    public void AddItem(string itemName)
    {
        //Debug.Log("itemSlot Length: " + itemSlot.Length);
        for (int i = 0; i < itemSlot.Length; i++)
        {

            if (!itemSlot[i].isFull)
            {

                collectedItems.Add(itemName);


                itemSlot[i].AddItem(itemName);


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


    public List<string> GetCollectedItems()
    {
        return collectedItems;
    }
}
