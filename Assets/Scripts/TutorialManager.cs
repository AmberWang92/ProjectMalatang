using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public GameObject tutorialPanel;

    private enum TutorialState
    {
        Welcome,
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
        if (Input.GetMouseButtonDown(1))
        {
            NextTutorialState();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ingredientsFound++;

            if (currentState == TutorialState.FindIngredients && ingredientsFound == 1)
            {
                currentState = TutorialState.GoodFindRestIngredients;
            }
            else if (currentState == TutorialState.GoodFindRestIngredients && ingredientsFound == 3)
            {
                currentState = TutorialState.ComeToCookingPot;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && currentState == TutorialState.ComeToCookingPot)
        {
            currentState = TutorialState.CookingMalatang;
        }
    }

    void ShowCurrentTutorialMessage()
    {
        switch (currentState)
        {
            case TutorialState.Welcome:
                ShowMessage("Welcome to Malatang Mayhem! It is a game where you need to gather ingredients and cook Malatang!");
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
                ShowMessage("Cooking Malatang... Tutorial completed!");
                tutorialPanel.SetActive(false);
                break;
        }
    }

    void ShowMessage(string message)
    {
        tutorialText.text = message + " Right click to skip.";
        tutorialPanel.SetActive(true);
    }

    void NextTutorialState()
    {
        switch (currentState)
        {
            case TutorialState.Welcome:
                currentState = TutorialState.FindIngredients;
                break;
            case TutorialState.FindIngredients:
                // Progress to the next state when the first ingredient is found (handled in the Update method)
                break;
            case TutorialState.GoodFindRestIngredients:
                // Progress to the next state when the required number of ingredients is found (handled in the Update method)
                break;
            case TutorialState.ComeToCookingPot:
                // Progress to the next state when the player presses 'E' (handled in the Update method)
                break;
            case TutorialState.CookingMalatang:
                // No further progression after completing the tutorial
                break;
        }

        ShowCurrentTutorialMessage();
    }
}
