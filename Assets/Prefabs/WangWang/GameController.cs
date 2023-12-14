using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] CookingPotScript cookingPot;
    private float gameTime = 30f; // Total game time in seconds
    private bool isGameOver = false;
    private bool isGameWon = false;
    public TMP_Text timerText; // Reference to the TextMeshPro Text object for the timer

    void Start()
    {
        // Find the TimerText object in the scene and assign it to the timerText variable
        timerText = GameObject.Find("TimerText").GetComponent<TMP_Text>();

        // Update the initial timer UI text
        UpdateTimerUI();
    }

    void Update()
    {
        if (!isGameOver && !isGameWon)
        {
            // Decrement the game time based on real time
            gameTime -= Time.deltaTime;

            // Ensure the timer doesn't go below zero
            gameTime = Mathf.Max(gameTime, 0f);

            // Update the timer UI text
            UpdateTimerUI();

            // Check if the game time reaches zero (the losing condition)
            if (gameTime <= 0f)
            {
                // Call a method to handle the game over condition
                GameOver();
            }

            // Check for the win condition (example: Player reaches the end point or achieves a specific goal)
            if (cookingPot.IsPlayerCooking())
            {
                GameWin();
            }
        }
    }

    void UpdateTimerUI()
    {
        // Update the timer UI text to display the remaining time
        timerText.text = "Time: " + Mathf.CeilToInt(gameTime).ToString(); // Display remaining time as an integer
    }

    void GameOver()
    {
        // Perform actions for game over (e.g., player loses)
        Debug.Log("Game Over! Time's up.");

        // Set the game over state to true to prevent further updates
        isGameOver = true;

        // Disable further gameplay elements, such as player controls or game logic
        // Example: Stop player movement, disable interactions, etc.
    }

    void GameWin()
    {
        // Perform actions for winning the game
        Debug.Log("Congratulations! You won!");

        // Set the game win state to true to prevent further updates
        isGameWon = true;

        // Disable further gameplay elements, such as player controls or game logic
        // Example: Stop player movement, disable interactions, etc.
    }
}
