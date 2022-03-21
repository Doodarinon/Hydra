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
    public int counter;

    private float timer;
    private int fenceAmmount;
    private float wanderSpeed = 0.5f;
    private float seeDistance = 250f;

    bool isDead = false;
    public LayerMask raycastLayers = 3;
    public GameObject player;
    public GameObject[] bunker;
    public GameObject[] fences1;
    public GameObject[] fences2;
    public GameObject[] fences3;
    public GameObject closestFence;
    public GameObject closestFence1;
    public GameObject closestFence2;
    public GameObject closestFence3;

    private Player_Controller playerController;
    private Bunker_Script bunkerScript;
    private PlayerHealth playerHealth;
    public EnemySpawner enemySpawner;
    public HealthBar healthBar;
    public NavMeshAgent nav;
    public Transform target;
    void Start()
    {
        playerController = GetComponent<Player_Controller>();
        bunkerScript = GetComponent<Bunker_Script>();
        playerHealth = GetComponent<PlayerHealth>();
        enemySpawner = GetComponent<EnemySpawner>();
        healthBar = GetComponent<HealthBar>();
        nav = GetComponent<NavMeshAgent>();
        fences1 = GameObject.FindGameObjectsWithTag("Fence1");
        fences2 = GameObject.FindGameObjectsWithTag("Fence2");
        fences3 = GameObject.FindGameObjectsWithTag("Fence3");
        player = GameObject.FindGameObjectWithTag("Player");
        // target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        counter = 0;
        bunker = GameObject.FindGameObjectsWithTag("Bunker");
        closestFence1 = fences1[counter];
        closestFence2 = fences2[counter];
        closestFence3 = fences3[counter];
        if (true) // Replace "True" with check that cheacks what lvl fences are in the 3 below
        {
            counter = 0;
            foreach (GameObject temp in fences1)
            {
                if (Vector3.Distance(transform.position, closestFence1.transform.position) > Vector3.Distance(transform.position, fences1[counter].transform.position))
                {
                    closestFence1 = fences1[counter];
                }
                counter++;
            }
        }
        if (true)
        {
            counter = 0;
            foreach (GameObject temp in fences2)
            {
                if (Vector3.Distance(transform.position, closestFence2.transform.position) > Vector3.Distance(transform.position, fences2[counter].transform.position))
                {
                    closestFence2 = fences2[counter];
                }
                counter++;
            }
        }
        if (true)
        {
            counter = 0;
            foreach (GameObject temp in fences3)
            {
                if (Vector3.Distance(transform.position, closestFence3.transform.position) > Vector3.Distance(transform.position, fences3[counter].transform.position))
                {
                    closestFence3 = fences3[counter];
                }
                counter++;
            }
        }
        Debug.Log("5");
        if (Vector3.Distance(transform.position, closestFence1.transform.position) < Vector3.Distance(transform.position,closestFence2.transform.position) && Vector3.Distance(transform.position, closestFence1.transform.position) < Vector3.Distance(transform.position, closestFence3.transform.position))
        {
            closestFence = closestFence1;
        }
        else if (Vector3.Distance(transform.position, closestFence2.transform.position) < Vector3.Distance(transform.position, closestFence3.transform.position))
        {
            closestFence = closestFence2;
            Debug.Log("2");
        }
        else
        {
            closestFence = closestFence3;
        }
        if (Vector3.Distance(transform.position, bunker[0].transform.position) < Vector3.Distance(transform.position, closestFence.transform.position) && Vector3.Distance(transform.position, bunker[0].transform.position) < Vector3.Distance(transform.position, player.transform.position))
        {
            target = bunker[0].transform;
        }
        else if (Vector3.Distance(transform.position, closestFence.transform.position) < Vector3.Distance(transform.position, player.transform.position))
        {
            target = closestFence.transform;
        }
        else
        {
            target = player.transform;
        }
        // *Input dynamic target choice here*

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
                //healthBar.SetHealth(playerHealth.currentPlayerHealth);

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