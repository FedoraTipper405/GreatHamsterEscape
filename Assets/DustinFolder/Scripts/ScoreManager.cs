using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Initial score
    public TextMeshProUGUI scoreText; // Text Mesh Pro element for displaying score
    [SerializeField]
    TextMeshProUGUI distanceText;
    float highestDistance;
    public int distanceInMeters;
    float playerStartX;
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
        playerStartX = gameObject.transform.position.x;
        highestDistance = playerStartX;
        // Initialize the score text at the start of the game
        UpdateScoreText();
    }
    private void Update()
    {
        //used for furthest distance score
        if(highestDistance < gameObject.transform.position.x)
        {
            distanceInMeters = ((int)((highestDistance - playerStartX) / 10));
            distanceText.text = "Distance: " + ((int)((highestDistance - playerStartX )/ 10));
            highestDistance = gameObject.transform.position.x;
        }
    }
}
