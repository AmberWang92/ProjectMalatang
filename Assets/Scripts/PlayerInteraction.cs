using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public CookingPotScript cookingPot;
    public PlayerInventory playerInventory;
    private GameObject playerGameObject;
    public float interactionDistance = 2f;
    public TMP_Text cookingText;
    public TMP_Text collectingText;


    void Start()
    {
        cookingText.enabled = false;
        playerGameObject = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(playerGameObject.transform.position, cookingPot.transform.position) <= interactionDistance)
        {
            cookingText.enabled = true;
            collectingText.enabled = false;

            if (Input.GetKeyDown(KeyCode.E))
            {

                if (playerGameObject != null)
                {
                    cookingPot.CookMalatang(playerInventory);
                }
            }
        }
    }
}
