using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //parameters
    [SerializeField] int totalblocks;

    //cached reference
    SceneLoader sceneLoader;
    Scene currentScene;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneLoader = FindObjectOfType<SceneLoader>();
        
    }
    public void CountBlocks()
    {
        totalblocks++;
    }

    public void BlockDestroyed()
    {
        string sceneName = currentScene.name;
        totalblocks--;
        if(totalblocks <= 0)
        {
           /* if(sceneName == "Level 2")
            {
                SceneManager.LoadScene("Level 1");
            }
            else*/
          //  {
                sceneLoader.LoadNextScene();
          //  }           
        }
    }
}
