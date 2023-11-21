using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionUI : MonoBehaviour
{
    // Slot class to represent a slot
    public class Slot
    {
        public GameObject slotObject; // Reference to the GameObject representing the slot
        public bool isEmpty = true; // Flag to check if the slot is empty
    }

    // Item class to represent an item
    public class Item
    {
        public GameObject itemObject; // Reference to the collected item GameObject
                                      // Add other properties or methods as needed
    }

}
