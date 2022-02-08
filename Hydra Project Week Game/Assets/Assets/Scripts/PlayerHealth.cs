using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float healthPlayer = 100;

    public void Update()
    {
        //Destroy object player can change to animation later
        if (healthPlayer <= 0)
        {
            Destroy(gameObject);
        }

    }



}
