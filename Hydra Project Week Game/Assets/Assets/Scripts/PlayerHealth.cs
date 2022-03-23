using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public float maxPlayerHealth = 100;
    public float currentPlayerHealth;
    public HealthBar healthbar;
    bool dead = false;

    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
        healthbar.SetMaxHealth(maxPlayerHealth);
    }
    public void Update()
    {
        //Right now this checks if player has 0 health and deletes the player if health below 0. Change this in futere. 
        //I destroy this object to not cause spamm in the console.
        if (currentPlayerHealth <= 0)
        {
            Debug.Log("dead");
            dead = true;
            if (dead == true)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
