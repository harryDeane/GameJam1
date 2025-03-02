using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEvent : MonoBehaviour
{
    public Transform speedBump;
    public GameObject box;
    private bool isMoving = false;

    private void Start()
    {
        EventManager.Instance.RegisterEvent("CarPasses", StartCar);
    }

    private void StartCar()
    {
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(transform.forward * Time.deltaTime * 5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            DropBox(); // Drop the box when colliding with the speed bump
            isMoving = false; // Stop the car
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            isMoving = false; // Stop the car
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.EndGame("Explosion");
            }
        }
    }

    private void DropBox()
    {
        // Get the Rigidbody of the existing box
        Rigidbody rb = box.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Apply force to make it jump out of the trailer
            rb.AddForce(transform.up * 5f + transform.forward * 3f, ForceMode.Impulse);
        }
    }
}


