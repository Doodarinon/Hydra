using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Inventory inventory;
    private PlayerHealth playerHealth;
    private PlayerStamina playerStamina;
    private HealthBar healthBar;
    private StaminaBar staminaBar;
    public BunkerScript bunkerScript;

    private float movementSpeed = 5;

    public int damage = 10;
    public float baseTimer = 1;
    public float dashCooldown;
    public float timer;
    public float dash;

<<<<<<< Updated upstream
=======
    private float staminaDrain = 0.1f;
    private float stamina = 0f;
    private float sprintSpeed = 1.2f;
>>>>>>> Stashed changes
    private Vector3 movement;
    //public Animator animator;

    Rigidbody rb;
    [SerializeField] private bool inCollider;
    // Declares player inventory.
    [SerializeField] private UIInventory uiInventory;

    void Start()
    {
        bunkerScript = FindObjectOfType<BunkerScript>().GetComponent<BunkerScript>();

        //animator = GetComponentInChildren<Animator>();

        rb = gameObject.GetComponent<Rigidbody>();

        playerHealth = gameObject.GetComponent<PlayerHealth>();
        healthBar = playerHealth.GetComponent<HealthBar>();
        playerStamina = gameObject.GetComponent<PlayerStamina>();
        staminaBar = playerStamina.GetComponent<StaminaBar>();

        // Creates player inventory.
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);

        // Spawns item(s).
        ItemInWorld.SpawnItemInWorld(new Vector3(10, 1, -5), new Item { itemType = Item.ItemType.Healthpack, amount = 1 });
        ItemInWorld.SpawnItemInWorld(new Vector3(5, 1, -10), new Item { itemType = Item.ItemType.Healthpack, amount = 1 });
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Upgrade"))
        {
            inCollider = true;
        }

        ItemInWorld itemInWorld = other.GetComponent<ItemInWorld>();

        // Pick up item. Touching target and sees if it's tagged as an item.
        if (other.CompareTag("Item") && other != null)
        {
            inventory.AddItem(itemInWorld.GetItem());
            itemInWorld.DestroySelf();
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Upgrade"))
        {
            inCollider = false;
        }
    }

    private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            // If item is a healthpack, +10 to current health.**
            case Item.ItemType.Healthpack:
                // *Provided that current health is below max value.
                if(playerHealth.currentPlayerHealth < playerHealth.maxPlayerHealth)
                {
                    playerHealth.currentPlayerHealth += 10;
                    playerHealth.healthBar.SetHealth(playerHealth.currentPlayerHealth);
                }
                inventory.RemoveItem(new Item { itemType = Item.ItemType.Healthpack, amount = 1 });
                break;
        }
        //Debug.Log("Item has been used");
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        transform.Translate(movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

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
        if (Input.GetButtonDown("Dash"))
        {
            PlayerDash();
        }
    }

    void PlayerDash()
    {
        if (dashCooldown <= 0)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, transform.position.y, Input.mousePosition.z);
            rb.AddRelativeForce(Vector3.forward * dash, ForceMode.Impulse);

            dashCooldown = 2f;
            playerStamina.UseStamina(10);

            //Debug.Log("Dash Succesful");
        }
    }

    void PlayerAttack()
    {
        //animator.Play("melee_attack");
        timer = baseTimer;
    }
    public void ButtonClick()
    {
        if (inCollider)
        {
            //bunkerScript.Upgrade();
        }
    }
}
