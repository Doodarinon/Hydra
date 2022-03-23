using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public float maxPlayerStamina = 50;
    public float currentPlayerStamina;
    public StaminaBar staminaBar;

    private Coroutine regenerate;
    // Wait for two seconds in between each tick...
    private WaitForSeconds regenerationTick = new WaitForSeconds(0.1f);

    private void Start()
    {
        currentPlayerStamina = maxPlayerStamina;
        staminaBar.SetMaxStamina(maxPlayerStamina);
    }

    /// <summary>
    /// Use specified amount of stamina.
    /// </summary>
    /// <param name="amount"></param>
    public void UseStamina(float amount)
    {
        if(currentPlayerStamina - amount >= 0)
        {
            currentPlayerStamina -= amount;
            staminaBar.SetStamina(currentPlayerStamina);

            if (regenerate != null)
                StopCoroutine(regenerate);

            regenerate = StartCoroutine(RegenerateStamina());
        }
    }

    /// <summary>
    /// Regenerates player's stamina.
    /// </summary>
    /// <returns></returns>
    private IEnumerator RegenerateStamina()
    {
        // Increase stamina by 2 each tick...
        yield return new WaitForSeconds(2);

        while(currentPlayerStamina < maxPlayerStamina)
        {
            currentPlayerStamina += maxPlayerStamina / 20;
            staminaBar.SetStamina(currentPlayerStamina);
            yield return regenerationTick;
        }
        regenerate = null;
    }
}
