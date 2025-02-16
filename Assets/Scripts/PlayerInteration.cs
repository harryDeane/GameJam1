using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public FireSpread fireSpreadScript; // Reference to the FireSpread script on the fire object

    private void Update()
    {
        // Detect if the player presses the "extinguish" button (e.g., "E" key) to stop the fire
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(transform.position, fireSpreadScript.transform.position) < 5f)
        {
            // If the player is close enough to the fire, extinguish it
            fireSpreadScript.ExtinguishFire();
        }
    }
}
