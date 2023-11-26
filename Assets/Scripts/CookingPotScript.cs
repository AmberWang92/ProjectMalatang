// CookingPotScript
using System.Collections.Generic;
using UnityEngine;

public class CookingPotScript : MonoBehaviour
{
    public List<string> requiredIngredients;

    public bool HasIngredients(PlayerInventory playerInventory)
    {
        if (playerInventory != null)
        {
            Debug.Log("Required Ingredients: " + string.Join(", ", requiredIngredients));

            foreach (string ingredient in requiredIngredients)
            {
                if (!playerInventory.HasItem(ingredient))
                {
                    Debug.Log("Missing ingredient: " + ingredient);
                    return false;
                }
            }
            Debug.Log("All ingredients found!");
            return true;
        }

        return false;
    }

    public void CookMalatang(PlayerInventory playerInventory)
    {
        Debug.Log("Checking ingredients before cooking:");

        foreach (string ingredient in requiredIngredients)
        {
            Debug.Log("Required Ingredient: " + ingredient);
        }

        Debug.Log("Player's Inventory Ingredients:");

        foreach (string ingredient in playerInventory.GetCollectedItems())
        {
            Debug.Log("Inventory Ingredient: " + ingredient);
        }

        if (playerInventory != null && HasIngredients(playerInventory))
        {
            Debug.Log("Malatang is cooking!");

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
