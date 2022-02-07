using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{

    public string scene;
    public void SceneSwitch()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
