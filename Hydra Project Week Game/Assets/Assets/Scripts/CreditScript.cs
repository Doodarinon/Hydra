using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    public void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
    public void IndieDBSite()
    {
        Application.OpenURL("https://www.indiedb.com/members/hydr-inc1");
    }
}
