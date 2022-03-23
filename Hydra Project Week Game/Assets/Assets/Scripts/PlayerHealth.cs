using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float healthPlayer = 100;
    public float currentPlayerHealth;
    public HealthBar healthbar;

    private void Start()
    {
        currentPlayerHealth = healthPlayer;
        healthbar.SetMaxHealth(healthPlayer);
    }
}
