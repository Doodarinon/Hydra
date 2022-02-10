using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;

    public float sliderValue;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = FindObjectOfType<Slider>().GetComponent<Slider>(); ;
        slider.value = PlayerPrefs.GetFloat("save", sliderValue);
    }
    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("save", sliderValue);
    }
    
}
