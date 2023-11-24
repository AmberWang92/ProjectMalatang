using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //========ITEM DATA========//
    public string itemName;
    public Sprite appleSprite;
    public Sprite carrotSprite;
    public Sprite leekSprite;
    public bool isFull;

    //========ITEM SLOT========//
    [SerializeField] private Image itemImage;

    public void AddItem(string itemName)
    {
        this.itemName = itemName;
        isFull = true;

        if (itemName == "apple")
        {
            itemImage.sprite = appleSprite;
            itemImage.enabled = true;
        }
        else if (itemName == "carrot")
        {
            itemImage.sprite = carrotSprite;
            itemImage.enabled = true;
        }
        else if (itemName == "leek")
        {
            itemImage.sprite = leekSprite;
            itemImage.enabled = true;
        }

        // switch (itemName)
        // {
        //     case "apple":
        //         itemImage.sprite = appleSprite;
        //         itemImage.enabled = true;
        //         break;
        //     case "carrot":
        //         itemImage.sprite = carrotSprite;
        //         itemImage.enabled = true;
        //         break;
        //     case "leek":
        //         itemImage.sprite = leekSprite;
        //         itemImage.enabled = true;
        //         break;
        //     default:
        //         break;
        // }
    }
}
