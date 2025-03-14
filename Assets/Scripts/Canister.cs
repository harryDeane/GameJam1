using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canister : MonoBehaviour
{
    public GameObject explosionEffectPrefab;  // Reference to explosion effect prefab

    public void Explode()
    {
        // Instantiate the explosion effect at the canisterís position
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

        // Optionally, apply force to nearby objects or destroy the canister
        Destroy(gameObject);  // Destroy the canister after explosion
    }
}
