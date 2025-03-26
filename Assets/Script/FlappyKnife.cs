using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FlappyScript : MonoBehaviour
{
    public Rigidbody2D thisRigidbody;
    public float flapStrength; // Strength of the flap (upward force)
    public float moveSpeed = 2f; // Speed for moving the screen horizontally
    public float horizontalBoundary = 2.5f; // Adjust based on screen width
    public Transform background; // Reference to the background
    public List<Transform> hazards = new List<Transform>(); // ✅ Ensure it's a list

    // public Transform[] hazards; // Array of hazard objects (e.g., rings, fruits, bombs)

    //public float rotationSpeed = 200f; // Speed of knife rotation

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

        MoveHazards();

        // RotateKnife();
    }

    // Method to move the screen horizontally (move the background)
    void MoveScreen()
    {
        // Move the background to the left automatically
        background.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
    void MoveHazards()
    {
        foreach (Transform hazard in hazards)
        {
            hazard.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

    }


    // void RotateKnife()
    // {
    //  transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    // }
    // ✅ Detect when the knife passes through the inner part of the ring
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InnerRing"))  // Safe zone inside the ring
        {
            Debug.Log("Passed Through the Ring! ✅");
            // Add points or any reward system here
        }
        if (other.CompareTag("LevelEnd"))
        {
            Debug.Log("Level Complete! ✅ Loading Next Level...");
            LoadNextLevel();
        }
        if (other.CompareTag("Fruit"))  // Fruit collection logic
        {
            if (other.CompareTag("Fruit"))  // Fruit collection logic
            {
                string fruitType = other.gameObject.name; // Get fruit name
                Debug.Log(fruitType + " Collected! ✅");

                FruitManager.instance.AddFruit(fruitType); // ✅ Add fruit to FruitManager

                RemoveHazard(other.transform); // ✅ Remove fruit from hazard list
                Destroy(other.gameObject); // Remove fruit from scene
            }
        }

        void RemoveHazard(Transform hazard)
        {
            if (hazards.Contains(hazard))
            {
                hazards.Remove(hazard);
            }
        }


    }

    // ❌ Detect when the knife touches the outer part of the ring (Game Over)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))  // Outer collision
        {
            Debug.Log("Hit the Outer Ring! ❌ Game Over");
            // Handle failure (e.g., restart game, lose life)
        }
    }

   
    void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1; // Get next scene index
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)  // Check if next scene exists
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No More Levels! Game Complete ✅");
            // You can reload the first level or show a win screen
            SceneManager.LoadScene(0); // Restart game
        }
    }


}
