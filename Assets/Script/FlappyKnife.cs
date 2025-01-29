using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyScript : MonoBehaviour
{
    public Rigidbody2D thisRigidbody;
    public float flapStrength; // Strength of the flap (upward force)
    public float moveSpeed = 2f; // Speed for moving the screen horizontally
    public float horizontalBoundary = 2.5f; // Adjust based on screen width
    public Transform background; // Reference to the background

    // Start is called before the first frame update
    void Start()
    {
        if (thisRigidbody == null)
        {
            thisRigidbody = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Flap up when Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisRigidbody.velocity = Vector2.up * flapStrength;
        }

        // Automatically move the screen horizontally
        MoveScreen();
    }

    // Method to move the screen horizontally (move the background)
    void MoveScreen()
    {
        // Move the background to the left automatically
        background.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
