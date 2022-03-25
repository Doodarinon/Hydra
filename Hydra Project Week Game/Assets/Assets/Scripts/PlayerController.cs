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
    public BunkerScript bunkerScript;
    private GameManager gameManager;

    private float movementSpeed = 5;
    private float dashCooldown;

    public float timer;
    public int damage = 10;
    public float baseTimer = 0.6f;
    public float dash;



    private Vector3 movement;
    public Animator animator;

    Rigidbody rb;
    [SerializeField] private bool inCollider;
    // Declares player inventory.
    [SerializeField] private UIInventory uiInventory;

    void Start()
    {
        /*try
        {
            bunkerScript = FindObjectOfType<BunkerScript>().GetComponent<BunkerScript>();
            animator = GetComponentInChildren<Animator>();
        }
        catch
        {
            throw;
        }*/
        rb = gameObject.GetComponent<Rigidbody>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();
        healthBar = playerHealth.GetComponent<HealthBar>();
        playerStamina = gameObject.GetComponent<PlayerStamina>();
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManager>();

        // Creates player inventory.
        //inventory = new Inventory(UseItem);
        //uiInventory.SetInventory(inventory);

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

        if(other.CompareTag("Resource") && other != null)
        {
            gameManager.Materials++;
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Upgrade"))
        {
            inCollider = false;
        }
    }

    /// <summary>
    /// Use item currently in player's inventory.
    /// </summary>
    /// <param name="item"></param>
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
        // Player movement.
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        transform.Translate(movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire") && timer <= 0 && playerStamina.currentPlayerStamina >= 5)
        {
            Debug.Log("works");
            PlayerAttack();
        }
    }

    private void FixedUpdate()
    {
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
            // Accelerates the player using mouse position and movement speed, then adds it to the current position.
            Vector3 mousePos = new Vector3(Input.mousePosition.x, transform.position.y, Input.mousePosition.z);
            rb.AddRelativeForce(Vector3.forward * dash, ForceMode.Impulse);

            dashCooldown = 2f;
            playerStamina.UseStamina(15);

            //Debug.Log("Dash Succesful");
        }
    }

    void PlayerAttack()
    {
        // Player cannot attack while in inventory.
        if (!uiInventory.state)
        {
        try
        {
            animator.Play("melee_attack");
        }
        catch
        {
            throw;
        }
            timer = baseTimer;
            playerStamina.UseStamina(5);
        }
    }
    public void ButtonClick()
    {
        if (inCollider)
        {
            //bunkerScript.Upgrade();
        }
    }
}
