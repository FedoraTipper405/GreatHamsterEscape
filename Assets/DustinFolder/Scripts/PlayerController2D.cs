using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player's movement
    public Rigidbody2D rb; // Reference to the player's Rigidbody2D

    private Vector2 movement;

    private void Update()
    {
        // Get input from the player
        movement.x = Input.GetAxisRaw("Horizontal"); // Left (-1) to Right (1)
    }

    private void FixedUpdate()
    {
        // Move the player based on input
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
