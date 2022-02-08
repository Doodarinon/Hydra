using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{

    public string scene1;
    public string scene2;
    public void SceneSwitch1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene1);
    }
    public void SceneSwitch2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene2);
    }
    public void Quit()
    {
        // Quits game both in Unity Editor and in the build
        
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();
    }
}
