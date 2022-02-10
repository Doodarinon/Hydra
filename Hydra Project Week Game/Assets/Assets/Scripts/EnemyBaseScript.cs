using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemyHealth = 10;
    public float damagePerHit = 0;
    public int attackspeed = 1;
    public PlayerHealth currentPlayerHealth;
    private float timer;
    bool notDead = false;
    public Transform target;
    public LayerMask raycastLayers;
    private NavMeshAgent nav;
    public float SeeDistece = 5f;

    public PlayerHealth playerHealth;
    public Player_Controller playerController;
    public HealthBar healthbar;
    public Bunker_Script bunkerScript;
    public EnemySpawner enemySpawner;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // If nothing is between this and target
        if (!Physics.Linecast(transform.position, target.position, out hit, raycastLayers))
        {
            // If in range, move to target
            if (Vector3.Distance(transform.position, target.position) < SeeDistece)
                nav.destination = target.position;


        }
    }

    //test

    private void OnCollisionStay(Collision collision)
    {

        if (collision.collider.CompareTag("Player"))
        {


            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                playerHealth.currentPlayerHealth -= damagePerHit;
                Debug.Log("hej");
                healthbar.SetHealth(currentPlayerHealth.currentPlayerHealth);

                timer = attackspeed;

            }

        }
        if (collision.collider.CompareTag("Bunker"))
        {
            bunkerScript.TakeDamage();
        }

    }
    /*private void OnCollisionStay(Collision collision)
    {



        if (collision.collider.CompareTag("Bunker"))
        {
            bunkerScript.TakeDamage();
        }

    }*/



    private void TakeDamage()
    {
        enemyHealth -= playerController.damage;
        if (enemyHealth <= 0 && !notDead)
        {
            notDead = true;
            enemySpawner.enemyCount -= 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.CompareTag("Weapon") && playerController.timer > 3)
            {
                TakeDamage();
            }
        }
    }

}