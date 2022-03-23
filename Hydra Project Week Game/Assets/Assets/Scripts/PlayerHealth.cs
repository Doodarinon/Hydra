using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxPlayerHealth = 100;
    public float currentPlayerHealth;
    public HealthBar healthbar;

    private bool isDead;

    private void Start()
    {
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
