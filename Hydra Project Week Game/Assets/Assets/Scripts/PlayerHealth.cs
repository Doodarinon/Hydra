using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public float maxPlayerHealth = 100;
    public float currentPlayerHealth = 0;
    public HealthBar healthbar;
    bool dead = false;

    private bool isDead;

    private void Start()
    {
        healthbar = FindObjectOfType<HealthBar>().GetComponent<HealthBar>();
        currentPlayerHealth = maxPlayerHealth;
        healthbar.SetMaxHealth(maxPlayerHealth);
    }
    private void Update()
    {
        if (currentPlayerHealth <= 0)
        {
            isDead = true;

            if (isDead)
                Destroy(this.gameObject);
        }
    }
}
