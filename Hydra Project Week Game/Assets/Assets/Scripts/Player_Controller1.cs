using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float movement_speed = 50f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // Sets "pos" as the players position
        // pos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, 0f, Input.GetAxis("Vertical") * Time.deltaTime);
        // movement.Normalize();
        rb.MovePosition(transform.position + movement * Time.deltaTime);
    }
}
