using System.Collections.Generic;
using UnityEngine;

public class CookingPotScript : MonoBehaviour
{
    public List<string> requiredIngredients;

    [SerializeField]
    private GameObject fullMalatangModel;

    private bool isCooking = false;

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

            // We remove all the ingredients from the player inventory
            foreach (string ingredient in requiredIngredients)
            {
                playerInventory.RemoveItem(ingredient);
            }


            // display the full malatang model if it exits
            if (fullMalatangModel != null)
            {
                fullMalatangModel.SetActive(true);
                Debug.Log("Full Malatang Model activated!");
            }
            else
            {
                Debug.LogError("Full Malatang Model is null!");
            }

            // player win the game
            isCooking = true;
        }
        else
        {
            Debug.Log("Not enough ingredients to cook Malatang.");
        }
    }



    public bool IsPlayerCooking()
    {
        return isCooking;
    }

}
