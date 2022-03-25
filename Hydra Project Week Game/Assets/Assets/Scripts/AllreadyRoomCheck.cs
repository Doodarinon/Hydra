using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllreadyRoomCheck : MonoBehaviour
{
    private CloseCollisionCheck collisionCheck;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bottom"))
        {
            collisionCheck = other.GetComponent<CloseCollisionCheck>();
            collisionCheck.done = true;
            Debug.Log(other.name);
        }
        if (other.CompareTag("Top"))
        {
            collisionCheck = other.GetComponent<CloseCollisionCheck>();
            collisionCheck.done = true;
            Debug.Log(other.name);
        }
        if (other.CompareTag("Left"))
        {
            collisionCheck = other.GetComponent<CloseCollisionCheck>();
            collisionCheck.done = true;
            Debug.Log(other.name);
        }
        if (other.CompareTag("Right"))
        {
            collisionCheck = other.GetComponent<CloseCollisionCheck>();
            collisionCheck.done = true;
            Debug.Log(other.name);
        }
    }
}
