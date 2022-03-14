using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    // Declares player inventory.
    [SerializeField] private UI_Inventory uiInventory;
    public Bunker_Script bunkerScript;
    private float movementSpeed = 5f;
    private Inventory inventory;
    public float baseTimer = 1f;
    public float dashCooldown;
    private Vector3 movement;
    public Animator animator;
    [SerializeField] private bool inCollider;
    public int damage = 10;
    public float timer;
    public float dash;
    Rigidbody rb;

    void Start()
    {
        bunkerScript = FindObjectOfType<Bunker_Script>().GetComponent<Bunker_Script>();
        animator = GetComponentInChildren<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        // Creates player inventory.
       // inventory = new Inventory();
       // uiInventory.SetInventory(inventory);
    }

    // Pick up item.
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Upgrade"))
        {
            inCollider = true;
        }

        Item item = other.GetComponent<Item>();

        if (other.CompareTag("Item") && other != null)
        {
            inventory.AddItem(item);
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Upgrade"))
        {
            inCollider = false;
        }

        Item item = other.GetComponent<Item>();

        if(other.CompareTag("Item") && other != null)
        {
            if (other.TryGetComponent(out Item item))
            {

                inventory.AddItem(item);
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
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
        // Accelerates the players rigidbody using movement (direction) and movementspeed and adds it to the current pos
        rb.MovePosition(transform.position + movement * movementSpeed * Time.fixedDeltaTime);
        dashCooldown -= Time.deltaTime;
        // Debug.Log(dashCooldown);
        if (Input.GetKeyDown("space"))
        {
            PlayerDash();
        }
    }

    void PlayerDash()
    {
        if (dashCooldown <= 0)
        {
            // Vector3 mousePos = new Vector3(Input.mousePosition.x, transform.position.y, Input.mousePosition.z);
            rb.AddRelativeForce(Vector3.forward * dash, ForceMode.Impulse);

            dashCooldown = 2f;

            Debug.Log("Dash Succesful");
        }
        else
        {
            Debug.Log("You have a cooldown for " + dashCooldown + " seconds");
        }

    }

    void PlayerAttack()
    {
        animator.Play("melee_attack");
        timer = baseTimer;
    }
    public void ButtonClick()
    {
        if (inCollider)
        {
            bunkerScript.Upgrade();
        }
    }

    // Use item.
    public void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.BaseBallBat:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.BaseBallBat, amount = 1 });
                break;
            case Item.ItemType.Healthpack:
                /*GetComponent<PlayerHealth>().currentPlayerHealth += 10;*/
                inventory.RemoveItem(new Item { itemType = Item.ItemType.Healthpack, amount = 1 });
                break;
        }
        Debug.Log("Item has been used.");
    }
}
