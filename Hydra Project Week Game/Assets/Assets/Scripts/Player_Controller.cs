using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float movement_speed = 5f;
<<<<<<< HEAD
    public Animator animator;
=======
    // Showcases inventory.
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    
>>>>>>> db2818cc9db16ef2c8ee8ca1173241079d808ccc

    Rigidbody rb;

    public float baseTimer = 5f;
    private float timer;
    // public GameObject player;

    // private Vector3 pos;

<<<<<<< HEAD
 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("attack", false);
=======
    // Start is called before the first frame update
    void Start()
    {
        // Sets "pos" as the players position
        // pos = player.transform.position;
        // Creates inventory.
        inventory = new Inventory();
        // Sets UI Inventory to match player's inventory.
        uiInventory.SetInventory(inventory);
>>>>>>> db2818cc9db16ef2c8ee8ca1173241079d808ccc
    }

    // Update is called once per frame
    void Update()
    {

        
        // Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") , 0f, Input.GetAxis("Vertical")).normalized;
        // movement.Normalize();
        rb.MovePosition(transform.position + movement * movement_speed * Time.deltaTime);


        // transform.Translate(movement_speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, movement_speed * Input.GetAxis("Vertical") * Time.deltaTime);

        if (timer > 0)
        {
<<<<<<< HEAD
            timer -= Time.deltaTime;
            Debug.Log("timer");
=======
            timer = -Time.deltaTime;
>>>>>>> db2818cc9db16ef2c8ee8ca1173241079d808ccc
        }
        if (Input.GetButtonDown("mouse 1") || timer <= 0)
        {
            Debug.Log("attack");
            PlayerAttack();
        }
    }

    void PlayerAttack()
    {
        animator.SetBool("attack", true);
        timer = baseTimer;
<<<<<<< HEAD


=======
>>>>>>> db2818cc9db16ef2c8ee8ca1173241079d808ccc
    }
}
