using System.Collections.Generic;
using UnityEngine;

public class CookingPotScript : MonoBehaviour
{
    public List<string> requiredIngredients;

    // This method checks if the required ingredients are present in the player's inventory.
    public bool HasIngredients(PlayerInventory playerInventory)
    {
        if (playerInventory != null)
        {
            foreach (string ingredient in requiredIngredients)
            {
                if (!playerInventory.HasItem(ingredient))
                {
                    return false;
                }
            }
            return true;
        }

        return false;
    }

    // This method is called when the player tries to cook Malatang.
    public void CookMalatang(PlayerInventory playerInventory)
    {
        if (playerInventory != null && HasIngredients(playerInventory))
        {
            // Implement cooking logic here
            Debug.Log("Malatang is cooking!");

            // Reset or consume the ingredients in the player's inventory as needed
            foreach (string ingredient in requiredIngredients)
            {
                playerInventory.RemoveItem(ingredient);
            }
        }
        else
        {
            Debug.Log("Not enough ingredients to cook Malatang.");
        }
    }
}
