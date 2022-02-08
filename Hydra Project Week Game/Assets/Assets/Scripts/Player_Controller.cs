using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float movement_speed = 5f;
    public Animator animator;

    Rigidbody rb;

    public float baseTimer = 5f;
    public int damage = 10;
    public float timer;
    // public GameObject player;

    // private Vector3 pos;

 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("attack", false);
    }

    // Update is called once per frame
    void Update()
    {

        
        // Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") , 0f, Input.GetAxis("Vertical"));
        // movement.Normalize();
        rb.MovePosition(transform.position + movement * movement_speed * Time.deltaTime);


        // transform.Translate(movement_speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, movement_speed * Input.GetAxis("Vertical") * Time.deltaTime);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            Debug.Log("timer");
        }
        if (Input.GetButtonDown("Fire1") && timer <= 0)
        {
            Debug.Log("attack");
            PlayerAttack();
        }
    }

    void PlayerAttack()
    {
        animator.SetBool("attack", true);
        timer = baseTimer;


    }
}
