using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public float minVelocity = 0.1f; // Minimum velocity to be considered "moving"

    private Rigidbody rb; // Reference to the Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the object is moving (velocity greater than the minimum threshold)
            if (rb.velocity.magnitude > minVelocity)
            {
                // Call the EndGame method if the object is moving
                GameManager gameManager = FindObjectOfType<GameManager>();
                if (gameManager != null)
                {
                    gameManager.EndGame("Bucket");
                }
            }
        }
    }
}
