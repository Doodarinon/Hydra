using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    private GameManager gameManager;

    public float maxPlayerHealth = 100;
    public float currentPlayerHealth;
    public HealthBar healthBar;

    private bool isDead;

    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
        healthBar.SetMaxHealth(maxPlayerHealth);
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }
    private void Update()
    {
        if (currentPlayerHealth <= 0)
        {
            isDead = true;

            if (isDead)
            {
                Destroy(this.gameObject);
                gameManager.GameOver = true;
            }
            else
                gameManager.GameOver = false;
        }
    }
}
