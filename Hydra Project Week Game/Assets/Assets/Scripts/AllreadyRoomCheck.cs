using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllreadyRoomCheck : MonoBehaviour
{
    private CloseCollisionCheck collisionCheck;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bottom") || other.CompareTag("Top") || other.CompareTag("Left") || other.CompareTag("Right"))
        {
            collisionCheck = other.GetComponent<CloseCollisionCheck>();
            collisionCheck.done = true;
        }
    }
}
