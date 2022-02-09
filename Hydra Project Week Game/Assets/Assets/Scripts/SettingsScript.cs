using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{

    public string scene1;
    
    GameObject audioIcon_1;
    GameObject audioIcon_2;
    GameObject audioIcon_3;

    private void Start()
    {
        audioIcon_1 = GameObject.Find("AudioIcon_1");
        audioIcon_2 = GameObject.Find("AudioIcon_2");
        audioIcon_3 = GameObject.Find("AudioIcon_3");
    }
    public void AudioIconChange(float sliderValue)
    {
        
        if (sliderValue < 0.33f)
        {
            audioIcon_1.SetActive(false);
            audioIcon_2.SetActive(false);
            audioIcon_3.SetActive(true);
        }
        else if (sliderValue < 0.66f && sliderValue > 0.33f)
        {
            audioIcon_1.SetActive(false);
            audioIcon_2.SetActive(true);
            audioIcon_3.SetActive(false);
        }
        else if (sliderValue > 0.66f)
        {
            audioIcon_1.SetActive(true);
            audioIcon_2.SetActive(false);
            audioIcon_3.SetActive(false);
        }
        else
        {
            audioIcon_1.SetActive(false);
            audioIcon_2.SetActive(false);
            audioIcon_3.SetActive(false);
        }
    }
    public void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene1);
    }
    
}
