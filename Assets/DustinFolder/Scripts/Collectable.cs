using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Points for this collectable
    [SerializeField] private int pointValue;

    // Positive or negative type (set in the Inspector)
    [SerializeField] private bool isPositive; // true = positive, false = negative
    [SerializeField] GameObject valueDisplay;

    private void Start()
    {
       // valueDisplay = Resources.Load<GameObject>("Assets/NathansFolder/CollectValueDisplay");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collectable triggered by player!");

            // Access the player's score manager (A ScoreManager script needs to be attached to the player)
            ScoreManager scoreManager = other.GetComponent<ScoreManager>();

            if (scoreManager != null)
            {
                // Update score based on the type of collectable
                if (isPositive)
                {
                    scoreManager.AddPoints(pointValue);
                }
                else
                {
                    scoreManager.AddPoints(-pointValue); // Subtract points for negative items
                }
                valueDisplay = GameObject.Find("PlaceHolder").GetComponent<PlaceHolder>().displayValue;
                GameObject valueSpawned = Instantiate(valueDisplay,gameObject.transform.position,Quaternion.identity);
                if (isPositive)
                {
                    valueSpawned.GetComponent<TextMeshPro>().text = "+" + pointValue.ToString();
                }
                else
                {
                    valueSpawned.GetComponent<TextMeshPro>().text = "-" + pointValue.ToString();
                }

                // Destroy the collectable after it's been collected
                Destroy(gameObject);
            }
        }
    }
}
