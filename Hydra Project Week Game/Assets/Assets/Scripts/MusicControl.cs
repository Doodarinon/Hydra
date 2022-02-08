using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControl : MonoBehaviour
{
    private void Awake()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");

        if (musicObj.Length > 1 || activeScene != SceneManager.GetSceneByName("StartMenu") && activeScene != SceneManager.GetSceneByName("Settings") || activeScene == SceneManager.GetSceneByName("Game"))
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
