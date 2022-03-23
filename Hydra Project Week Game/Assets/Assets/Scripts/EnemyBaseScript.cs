using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBaseScript : MonoBehaviour
{
    public float enemyHealth = 10;
    public float damagePerHit = 0;
    public int attackSpeed = 1;
    public float wanderTime;

    private float timer;
    private float wanderSpeed = 0.5f;
    private float seeDistance = 250f;

    bool isDead = false;
    public LayerMask raycastLayers = 3;

    private PlayerController playerController;
    private BunkerScript bunkerScript;
    private PlayerHealth playerHealth;
    public EnemySpawner enemySpawner;
    public HealthBar healthBar;
    private NavMeshAgent nav;
    public Transform target;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        bunkerScript = GetComponent<BunkerScript>();
        playerHealth = GetComponent<PlayerHealth>();
        enemySpawner = GetComponent<EnemySpawner>();
        healthBar = GetComponent<HealthBar>();
        nav = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        // If nothing is between this and target
        if (!Physics.Linecast(transform.position, target.position, out hit, raycastLayers))
        {
            // If in range, move to target
            if (Vector3.Distance(transform.position, target.position) < seeDistance)
            {
                nav.destination = target.position;
            }
        }

        if (wanderTime > 0)
        {
            transform.Translate(Vector3.forward * wanderSpeed);
            wanderTime -= Time.deltaTime;
        }
        else
        {
            // Enemy will wander around same area for random amount of time, before changing position.
            wanderTime = Random.Range(5f, 15f);
            Wander();
        }
    }

    void Wander()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

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
                healthBar.SetHealth(playerHealth.currentPlayerHealth);

                timer = attackSpeed;

            }

        }
        if (collision.collider.CompareTag("Bunker"))
        {
            bunkerScript.TakeDamage();
        }

    }

    private void TakeDamage()
    {
        enemyHealth -= playerController.damage;
        if (enemyHealth <= 0 && !isDead)
        {
            isDead = true;
            enemySpawner.enemyCount -= 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && playerController.timer > 0)
        {
            TakeDamage();
        }
    }
}