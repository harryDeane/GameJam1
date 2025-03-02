using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Change "GameScene" to your actual game scene name
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the current scene
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu"); // Change "MainMenu" to your actual menu scene name
    }

    public void QuitGame()
    {
        Application.Quit(); // Closes the game (Only works in a built game)
    }
}
