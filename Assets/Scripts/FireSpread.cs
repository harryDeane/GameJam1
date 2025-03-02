using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{
    public GameManager gameManager;  // Reference to the GameManager

    public GameObject firePrefab;  // Reference to the fire prefab
    public GameObject canister;    // Reference to the canister
    public float spreadSpeed = 1f; // Speed at which the fire spreads
    public List<Transform> firePoints;  // List of fire spread points
    public float explosionRadius = 5f;  // Radius to trigger explosion when fire reaches the canister
    public float fireSpawnInterval = 1f; // Time interval between fire instantiations
    private bool fireExtinguished = false;  // Flag to track if the fire is extinguished

    private bool isSpreading = false; // To check if fire is currently spreading
    private int currentPointIndex = 0;  // To track the current fire point index

    private void Start()
    {
        EventManager.Instance.RegisterEvent("PowerlineFire", StartFireSpread);  // Listen for the PowerlineHit event
    }

    private void StartFireSpread()
    {
        if (!fireExtinguished && !isSpreading && firePoints.Count > 0)
        {
            StartCoroutine(SpreadFire()); // Start spreading the fire after the PowerlineHit event
        }
        else
        {
            Debug.LogWarning("Fire Spread not starting. Ensure firePoints are set correctly.");
        }
    }

    private IEnumerator SpreadFire()
    {
        isSpreading = true;
        Debug.Log("Fire spread started!");

        while (!fireExtinguished && currentPointIndex < firePoints.Count)
        {
            Transform targetPoint = firePoints[currentPointIndex];
            Vector3 directionToNextPoint = targetPoint.position - transform.position;

            // Debug log to track movement
            Debug.Log($"Moving towards: {targetPoint.name}, Current position: {transform.position}, Target position: {targetPoint.position}");

            // Move the fire towards the next point
            transform.Translate(directionToNextPoint.normalized * spreadSpeed * Time.deltaTime);

            // Check if the fire has reached the current target point
            if (Vector3.Distance(transform.position, targetPoint.position) < 1f)
            {
                // Instantiate a new fire effect at the target point
                Debug.Log($"Spawning fire at point {targetPoint.name}");
                Instantiate(firePrefab, targetPoint.position, Quaternion.identity);

                // Check if the fire has reached the canister
                if (Vector3.Distance(transform.position, canister.transform.position) < explosionRadius)
                {
                    ExplodeCanister();
                    break;  // Stop spreading the fire if it has exploded
                }

                // Move to the next fire point
                currentPointIndex++;
            }

            // Wait for a defined interval before moving to the next fire point
            yield return new WaitForSeconds(fireSpawnInterval);
        }

        isSpreading = false;
    }

    private void ExplodeCanister()
    {
        // Trigger the explosion effect on the canister
        Canister canisterScript = canister.GetComponent<Canister>();
        if (canisterScript != null)
        {
            canisterScript.Explode();
            // Call the GameManager's EndGame method when the canister explodes
            gameManager.EndGame("Explosion");
        }

        Debug.Log("Canister Exploded!");
    }

    public void ExtinguishFire()
    {
        fireExtinguished = false;
        Debug.Log("Fire Extinguished!");
    }
}
