using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float movement_speed = 5f;
<<<<<<< HEAD
    Rigidbody rb;
=======
    public float baseTimer = 5f;
    private float timer;
    // public GameObject player;

    // private Vector3 pos;

>>>>>>> 4519b766c661dad8ae50196fcf734300603507c3
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
<<<<<<< HEAD
        
        // Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") , 0f, Input.GetAxis("Vertical"));
        // movement.Normalize();
        rb.MovePosition(transform.position + movement * movement_speed*  Time.deltaTime);
=======

        transform.Translate(movement_speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, movement_speed * Input.GetAxis("Vertical") * Time.deltaTime);

        if (timer > 0)
        {
            timer = -Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire2") || timer <= 0)
        {
            PlayerAttack();
        }
    }

    void PlayerAttack()
    {

        timer = baseTimer;
>>>>>>> 4519b766c661dad8ae50196fcf734300603507c3
    }
}
