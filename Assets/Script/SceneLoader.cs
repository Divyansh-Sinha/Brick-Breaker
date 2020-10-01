using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Returns the index of the current scene.
        SceneManager.LoadScene(currentSceneIndex + 1); // Loads the next scene 
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().GameReset();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
