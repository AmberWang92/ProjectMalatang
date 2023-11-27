using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public GameObject tutorialPanel;
    public PlayerInventory playerInventory; // Reference to the PlayerInventory

    private enum TutorialState
    {
        Welcome,
        RightClickToProceed,
        FindIngredients,
        GoodFindRestIngredients,
        ComeToCookingPot,
        CookingMalatang,
        Completed
    }

    private TutorialState currentState;
    private int ingredientsFound = 0;

    void Start()
    {
        currentState = TutorialState.Welcome;
        ShowCurrentTutorialMessage();
    }

    void Update()
    {
        // Check for right-click to proceed to the next tutorial message
        if (Input.GetMouseButtonDown(1))
        {
            NextTutorialState();
        }
    }

    void ShowCurrentTutorialMessage()
    {
        switch (currentState)
        {
            case TutorialState.Welcome:
                ShowMessage("Welcome to Malatang Mayhem! It is a game where you need to gather ingredients and cook Malatang.");
                break;
            case TutorialState.FindIngredients:
                ShowMessage("Find ingredients for your Malatang.");
                break;
            case TutorialState.GoodFindRestIngredients:
                ShowMessage("Good! Now go and find the remaining 2 ingredients.");
                break;
            case TutorialState.ComeToCookingPot:
                ShowMessage("Come to the cooking pot and press E to start cooking Malatang.");
                break;
            case TutorialState.CookingMalatang:
                ShowMessage("Cooking Malatang...");
                break;
            case TutorialState.Completed:
                tutorialPanel.SetActive(false); // Hide the tutorial panel when the tutorial is completed
                break;
        }
    }

    void ShowMessage(string message)
    {
        tutorialText.text = message;
        tutorialPanel.SetActive(true);
    }

    void NextTutorialState()
    {
        Debug.Log("Current State: " + currentState);

        switch (currentState)
        {
            case TutorialState.Welcome:
                currentState = TutorialState.RightClickToProceed;
                break;
            case TutorialState.RightClickToProceed:
                currentState = TutorialState.FindIngredients;
                break;
            case TutorialState.FindIngredients:
                // Check if all ingredients are found to transition to the next state
                if (ingredientsFound >= 3)
                {
                    currentState = TutorialState.GoodFindRestIngredients;
                }
                break;
            case TutorialState.GoodFindRestIngredients:
                // Check if all ingredients are found to transition to the next state
                if (ingredientsFound >= 3)
                {
                    currentState = TutorialState.ComeToCookingPot;
                }
                break;
            case TutorialState.ComeToCookingPot:
                // Check if all ingredients are found to transition to the next state
                if (ingredientsFound >= 3)
                {
                    currentState = TutorialState.CookingMalatang;
                }
                break;
            case TutorialState.CookingMalatang:
                // Simulate the cooking process (you can replace this with your actual logic)
                // For demonstration purposes, transition to the next state immediately
                currentState = TutorialState.Completed;
                break;
        }

        Debug.Log("Next State: " + currentState);
        ShowCurrentTutorialMessage();
    }

    // Call this method when the player finds an ingredient
    public void IngredientFound()
    {
        ingredientsFound++;
    }
}
