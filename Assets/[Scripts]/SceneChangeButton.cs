using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{

   public void OnButtonPressed()
    {
        SceneManager.LoadScene(tag);
    }

    public void LoadpreviousScene()
    {
       int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(sceneIndex > 0)
        { 
            SceneManager.LoadScene(sceneIndex-1);
        }
        else
        {
            Debug.Log("cannot Load previous Scene. this is the first one");
        }
    }

    public void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if( sceneIndex < SceneManager.sceneCountInBuildSettings)
        { 
            SceneManager.LoadScene(sceneIndex + 1);
        }
        else
        {
            Debug.Log("Cannot load next scene. this is the last one");
        }
    }
}
