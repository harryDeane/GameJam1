using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderEvent : MonoBehaviour
{
    public GameObject powerLine; // Reference to the powerline
    private Rigidbody rb;
    private bool hasFallen = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Prevent it from falling initially
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !hasFallen)
        {
            Debug.Log("Ball hit the ladder! Ladder is falling.");
            hasFallen = true;
            rb.isKinematic = false; // Enable physics to let it fall
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == powerLine)
        {
            Debug.Log("Ladder hit the powerline!");
            EventManager.Instance.TriggerEvent("PowerlineHit"); // Trigger next event
            EventManager.Instance.TriggerEvent("PowerlineFire"); // Trigger next event
        }
    }
}

