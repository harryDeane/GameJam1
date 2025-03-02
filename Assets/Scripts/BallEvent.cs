using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEvent : MonoBehaviour
{
    private Rigidbody rb;
    private bool canInteract = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            StopBall();
        }
    }

    private void StopBall()
    {
        rb.isKinematic = true; // Stops the ball from rolling
        EventManager.Instance.TriggerEvent("CarPasses"); // Triggers the alternate event
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            StopBall();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}

