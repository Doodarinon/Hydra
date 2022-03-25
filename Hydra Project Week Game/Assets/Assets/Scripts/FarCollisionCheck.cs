using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarCollisionCheck : MonoBehaviour
{
    public bool occupied;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tile") && !occupied)
        {
            occupied = true;
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
