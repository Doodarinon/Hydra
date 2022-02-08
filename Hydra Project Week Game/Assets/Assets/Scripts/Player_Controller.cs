using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float movement_speed = 5f;
    public Animator animator;
<<<<<<< HEAD
    // Showcases inventory.
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    public float baseTimer = 5f;
    private float timer;
    Rigidbody rb;
=======

    Rigidbody rb;

    public float baseTimer = 5f;
    public int damage = 10;
    public float timer;
    // public GameObject player;

    // private Vector3 pos;

>>>>>>> parent of 3ac5985 (this should work)
 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        animator.SetBool("attack", false);
<<<<<<< HEAD
        inventory = new Inventory();
        // Sets UI Inventory to match player's inventory.
        uiInventory.SetInventory(inventory);
=======
>>>>>>> parent of 3ac5985 (this should work)
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") , 0f, Input.GetAxis("Vertical"));
        // movement.Normalize();
        rb.MovePosition(transform.position + movement * movement_speed * Time.deltaTime);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
<<<<<<< HEAD
        }
        if (Input.GetButtonDown("Fire2") || timer <= 0)
=======
            Debug.Log("timer");
        }
        if (Input.GetButtonDown("Fire1") && timer <= 0)
>>>>>>> parent of 3ac5985 (this should work)
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


>>>>>>> parent of 3ac5985 (this should work)
    }
}
