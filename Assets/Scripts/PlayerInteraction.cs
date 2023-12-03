using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public CookingPotScript cookingPot;
    public PlayerInventory playerInventory;
    public float interactionDistance = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteractWithCookingPot();
        }
    }

    void TryInteractWithCookingPot()
    {

        GameObject playerGameObject = GameObject.FindWithTag("Player");

        if (playerGameObject != null)
        {


            if (Vector3.Distance(playerGameObject.transform.position, cookingPot.transform.position) <= interactionDistance)
            {
                cookingPot.CookMalatang(playerInventory);
            }
            else
            {
                Debug.Log("Too far from the pot to interact.");
            }
        }
        else
        {
            Debug.LogError("Player GameObject not found.");
        }
    }
}
