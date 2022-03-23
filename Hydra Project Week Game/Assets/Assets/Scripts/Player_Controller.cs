using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    private Inventory inventory;
    public Bunker_Script bunkerScript;

    private float movementSpeed = 5f;

    public int damage = 10;
    public float baseTimer = 1f;
    public float dashCooldown;
    public float timer;
    public float dash;

    private float staminaDrain = 0.1f;
    private float stamina = 0f;
    private Image staminaBar;
    private float sprintSpeed = 1.2f;
    private Vector3 movement;
    public Animator animator;

    Rigidbody rb;
    [SerializeField] private bool inCollider;
    // Declares player inventory.
    [SerializeField] private UI_Inventory uiInventory;

    void Start()
    {
        try
        {
            animator = GetComponentInChildren<Animator>();
            bunkerScript = FindObjectOfType<Bunker_Script>().GetComponent<Bunker_Script>();
        }
        catch (System.Exception)
        {
            Debug.Log("Either animator or bunker script or both dont exist, should be fine without");
            throw;
        }


        rb = gameObject.GetComponent<Rigidbody>();

        // Creates player inventory.
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        // Spawns item(s).
        ItemInWorld.SpawnItemInWorld(new Vector3(10, 1, -5), new Item { itemType = Item.ItemType.Healthpack, amount = 1 });
        ItemInWorld.SpawnItemInWorld(new Vector3(10, 1, -10), new Item { itemType = Item.ItemType.Healthpack, amount = 1 });
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
        if (other.CompareTag("Upgrade"))
        {
            inCollider = false;
        }
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

    /*private void FixedUpdate()
    {
        // Accelerates the players rigidbody using movement (direction) and movementspeed and adds it to the current pos
        rb.MovePosition(transform.position + movement * movementSpeed * Time.fixedDeltaTime);
        dashCooldown -= Time.deltaTime;
        // Debug.Log(dashCooldown);
        if (Input.GetKeyDown("space"))
        {
            PlayerDash();
        }
    }*/

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
        try
        {
            timer = baseTimer;
            animator.Play("melee_attack");
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void ButtonClick()
    {
        if (inCollider)
        {
            try
            {
                bunkerScript.Upgrade();
            }
            catch
            {
                throw;
            }
        }
    }
}
