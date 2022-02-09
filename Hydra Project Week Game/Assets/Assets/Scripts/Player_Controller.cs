using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    

    public float movementSpeed = 5f;
    Rigidbody rb;

    
    public float dashCooldown;
    public float dash;
    // private Vector3 dashLength;
   

    public float baseTimer = 5f;
    public int damage = 10;
    public float timer;
 
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
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") , 0f, Input.GetAxis("Vertical")).normalized;
        // movement.Normalize();
        rb.MovePosition(transform.position + movement * movementSpeed * Time.deltaTime);


        // transform.Translate(movement_speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, movement_speed * Input.GetAxis("Vertical") * Time.deltaTime);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && timer <= 0)
        {
            PlayerAttack();
        }
    }
    
    private void FixedUpdate()
    {
        dashCooldown -= Time.deltaTime;
        // Debug.Log(dashCooldown);
        PlayerDash();
    }

    void PlayerDash()
    {
        if (dashCooldown <= 0)
        {
            if (Input.GetKeyDown("space"))
            {
                // Vector3 mousePos = new Vector3(Input.mousePosition.x, transform.position.y, Input.mousePosition.z);
                rb.AddRelativeForce(Vector3.forward * dash, ForceMode.Impulse);

                dashCooldown = 2f;

                Debug.Log("Dash Succesful");
            }
        }
        else
        {
            Debug.Log("You have a cooldown for " + dashCooldown + " seconds");
        }

    }
    

    void PlayerAttack()
    {

        timer = baseTimer;

    }
}
