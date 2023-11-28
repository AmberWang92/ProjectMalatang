using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public Canvas tutorialCanvas; 
    public PlayerInventory playerInventory; 

    private enum TutorialState
    {
        Welcome,
        FindIngredients,
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
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            NextTutorialState();
        }
    }

    void ShowCurrentTutorialMessage()
    {
        switch (currentState)
        {
            case TutorialState.Welcome:
                ShowMessage("Welcome to Malatang Mayhem! It is a game where you need to gather ingredients and cook Malatang. Press Q to continue.");
                break;
            case TutorialState.FindIngredients:
                ShowMessage("Find ingredients for your Malatang, then find cooking pot and press E to cook.");
                break;
            case TutorialState.Completed:
                HideTutorialCanvas();
                break;
        }
    }

    void ShowMessage(string message)
    {
        tutorialText.text = message;
        tutorialCanvas.gameObject.SetActive(!string.IsNullOrEmpty(message));
    }

    void HideTutorialCanvas()
    {
        tutorialCanvas.gameObject.SetActive(false);
    }

    void NextTutorialState()
    {
        Debug.Log("Current State: " + currentState);

        switch (currentState)
        {
            case TutorialState.Welcome:
                currentState = TutorialState.FindIngredients;
                break;
            case TutorialState.FindIngredients:
                currentState = TutorialState.Completed;
                break;
            case TutorialState.Completed:
                HideTutorialCanvas();
                break;
        }

        Debug.Log("Next State: " + currentState);
        ShowCurrentTutorialMessage();
    }

  
    public void IngredientFound()
    {
        ingredientsFound++;

       
        if (currentState == TutorialState.FindIngredients && ingredientsFound >= 3)
        {
            NextTutorialState();
        }
    }
}
