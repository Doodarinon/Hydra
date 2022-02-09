using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControl : MonoBehaviour
{
    
    private void FixedUpdate()
    {
         Scene activeScene = SceneManager.GetActiveScene();

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");

        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (activeScene != SceneManager.GetSceneByName("StartMenu") && activeScene != SceneManager.GetSceneByName("Settings"))
        {
            Destroy(this.gameObject);
        }
        else if (activeScene == SceneManager.GetSceneByName("Game"))
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
