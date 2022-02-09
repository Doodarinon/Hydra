using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float movement_speed = 5f;
    public Animator animator;
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    public float baseTimer = 5f;
    public float timer;
    Rigidbody rb;
    public int damage = 10;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }
    void Update()
    {
        // Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") , 0f, Input.GetAxis("Vertical"));
        // movement.Normalize();
        rb.MovePosition(transform.position + movement * movement_speed * Time.deltaTime);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (Input.GetButton("Fire2") && timer <= 0)
        {
            animator.Play("melee_attack");
            timer = baseTimer;
        }
    }
}
