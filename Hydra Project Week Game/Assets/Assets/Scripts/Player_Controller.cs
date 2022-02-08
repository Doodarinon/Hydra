using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float movement_speed = 5f;
    public Animator animator;
    // Showcases inventory.
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    public float baseTimer = 5f;
    private float timer;
    Rigidbody rb;
 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        animator.SetBool("attack", false);
        inventory = new Inventory();
        // Sets UI Inventory to match player's inventory.
        uiInventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") , 0f, Input.GetAxis("Vertical")).normalized;
        // movement.Normalize();
        rb.MovePosition(transform.position + movement * movement_speed * Time.deltaTime);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
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
    }
}
