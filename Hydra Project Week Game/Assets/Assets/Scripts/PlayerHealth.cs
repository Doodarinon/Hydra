using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float healthPlayer = 100;
    public float currentPlayerHealth;

    public HealthBar healthbar;
    
    public void Start()
    {

        currentPlayerHealth += healthPlayer;
        SetMaxHealth(healthPlayer);
    }
    public void Update()
    {
        //Destroy object player can change to animation later
        if (currentPlayerHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    public Slider slider;
    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(float health)
    {
        slider.value = health;
    }

    


}
