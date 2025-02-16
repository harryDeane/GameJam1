using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerlineEvent : MonoBehaviour
{
    public GameObject sparkEffectPrefab;  // Reference to the spark effect prefab
    public GameObject fireEffectPrefab;   // Reference to the fire effect prefab

    public Vector3 fireOffset = new Vector3(0, 2, 0);  // Offset for fire spawn position
    public float fireDelay = 3f;  // Delay before fire starts

    private void Start()
    {
        EventManager.Instance.RegisterEvent("PowerlineHit", PowerlineBreak);
    }

    private void PowerlineBreak()
    {
        Debug.Log("Powerline is sparking and breaking!");

        // Instantiate the spark effect at the powerline's position
        Instantiate(sparkEffectPrefab, transform.position, transform.rotation);

        // Start the coroutine to delay the fire effect
        StartCoroutine(WaitForFireEffect());
    }

    private IEnumerator WaitForFireEffect()
    {
        // Wait for the specified delay before spawning the fire
        yield return new WaitForSeconds(fireDelay);

        // Instantiate the fire effect after the delay at the specified offset position
        Instantiate(fireEffectPrefab, transform.position + fireOffset, transform.rotation);

        // Optionally, add sounds or other effects here
    }
}

