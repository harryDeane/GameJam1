using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // If you want to display UI elements like a Game Over text

public class GameManager : MonoBehaviour
{
    public Text gameOverText;  // A UI Text element to show Game Over message
    private bool gameIsOver = false;

    void Start()
    {
        // Ensure the game is running initially and game over text is hidden
        gameOverText.gameObject.SetActive(false);
        gameIsOver = false;
    }

    public void EndGame()
    {
        if (gameIsOver)
            return;

        gameIsOver = true;
        // Display the game over UI (if you have one)
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over! The Canister Exploded!";

        // Optionally, you can stop all other game activities here
        Time.timeScale = 0f;  // Freeze time to stop all gameplay

        // You can also add a restart function if needed
        // Invoke("RestartGame", 3f);  // Restart after 3 seconds
    }

    // Example Restart Function (if you want the player to restart the game)
    public void RestartGame()
    {
        Time.timeScale = 1f;  // Unfreeze time
        // Reload the scene or reset necessary values
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
