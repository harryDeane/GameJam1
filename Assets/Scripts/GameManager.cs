using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator playerAnimator; // Reference to player's Animator
    public GameObject player; // Reference to the player object

    public void EndGame(string deathType)
    {
        // Disable player movement (if applicable)
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }


        // Play different animations based on death type
        if (playerAnimator != null)
        {
            switch (deathType)
            {
                case "Bucket":
                    playerAnimator.SetTrigger("DeathByBucket");
                    break;
                case "Fire":
                    playerAnimator.SetTrigger("DeathByFire");
                    break;
                case "Explosion":
                    playerAnimator.SetTrigger("DeathByExplosion");
                    break;
                default:
                    playerAnimator.SetTrigger("GenericDeath");
                    break;
            }
        }

        // Start the restart process after a delay
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        SceneManager.LoadScene("End"); // Load the restart scene
    }
}
