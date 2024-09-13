using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Initial score
    public TextMeshProUGUI scoreText; // Text Mesh Pro element for displaying score

    // Method to add points
    public void AddPoints(int points)
    {
        score += points;

        // Ensure the score doesn't go below 0
        if (score < 0)
        {
            score = 0;
        }

        UpdateScoreText();
    }

    // Update the UI with the current score
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Start method to initialize the text
    private void Start()
    {
        // Initialize the score text at the start of the game
        UpdateScoreText();
    }
}
