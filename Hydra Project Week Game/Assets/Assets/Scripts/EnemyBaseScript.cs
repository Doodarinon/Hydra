using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBaseScript : MonoBehaviour
{
    public float enemyHealth = 10;
    private float damagePerHit = 3;
    public int attackSpeed = 1;
    public float wanderTime;
    public float damageTimer;
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

    private PlayerController playerController;
    private BunkerScript bunkerScript;
    private PlayerHealth playerHealth;
    private EnemySpawner enemySpawner;
    private FenceUpgrade fenceUpgrade;
    private HealthBar healthBar;
    private NavMeshAgent nav;
    private Transform target;
    void Start()
    {
        playerController =  FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        playerHealth =  FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
        enemySpawner =  FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();
        fenceUpgrade = FindObjectOfType<FenceUpgrade>().GetComponent<FenceUpgrade>();
        healthBar =  FindObjectOfType<HealthBar>().GetComponent<HealthBar>();
        bunkerScript =  FindObjectOfType<BunkerScript>().GetComponent<BunkerScript>();
        nav = GetComponent<NavMeshAgent>();
        fences1 = GameObject.FindGameObjectsWithTag("Fence1");
        fences2 = GameObject.FindGameObjectsWithTag("Fence2");
        fences3 = GameObject.FindGameObjectsWithTag("Fence3");
        player = GameObject.FindGameObjectWithTag("Player");
        fenceUpgrade.fences1.SetActive(false);
        fenceUpgrade.fences2.SetActive(false);
        fenceUpgrade.fences3.SetActive(false);
        // target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (fences1 == null && fenceUpgrade.fenceLvl == 1)
        {
            FenceUpgradeChecker();
        }
        if (fences2 == null && fenceUpgrade.fenceLvl == 2)
        {
            FenceUpgradeChecker();
        }
        if (fences3 == null && fenceUpgrade.fenceLvl == 3)
        {
            FenceUpgradeChecker();
        }
        bunker = GameObject.FindGameObjectsWithTag("Bunker");
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
        if (fenceUpgrade.fenceLvl > 0)
        {
            if (fenceUpgrade.fenceLvl == 1 && fences1 != null) // Replace "True" with check that cheacks what lvl fences are in the 3 below
            {
                counter = 0;
                closestFence = fences1[counter];
                foreach (GameObject temp in fences1)
                {
                    if (Vector3.Distance(transform.position, closestFence.transform.position) > Vector3.Distance(transform.position, fences1[counter].transform.position))
                    {
                        closestFence = fences1[counter];
                    }
                    counter++;
                }
            }
            else if (fenceUpgrade.fenceLvl == 2 && fences2 != null)
            {
                counter = 0;
                closestFence = fences2[counter];
                foreach (GameObject temp in fences2)
                {
                    if (Vector3.Distance(transform.position, closestFence.transform.position) > Vector3.Distance(transform.position, fences2[counter].transform.position))
                    {
                        closestFence = fences2[counter];
                    }
                    counter++;
                }
            }
            else if (fenceUpgrade.fenceLvl == 3 && fences3 != null)
            {
                counter = 0;
                closestFence = fences3[counter];
                foreach (GameObject temp in fences3)
                {
                    if (Vector3.Distance(transform.position, closestFence.transform.position) > Vector3.Distance(transform.position, fences3[counter].transform.position))
                    {
                        closestFence = fences3[counter];
                    }
                    counter++;
                }
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
        }
        else
        {
            if (Vector3.Distance(transform.position, bunker[0].transform.position) < Vector3.Distance(transform.position, player.transform.position))
            {
                target = bunker[0].transform;
            }
            else
            {
                target = player.transform;
            }
        }

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
        else if (wanderTime > 0)
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
        if (collision.collider.CompareTag("Bunker") && bunkerScript.timer <= 0)
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
        if (other.CompareTag("Weapon") && playerController.Timer > 0)
        {
            damageTimer = playerController.timer;
            TakeDamage();
        }
    }
    public void FenceUpgradeChecker()
    {
        if (fenceUpgrade.fenceLvl == 1)
        {
            fences1 = GameObject.FindGameObjectsWithTag("Fence1");
        }
        if (fenceUpgrade.fenceLvl == 2)
        {
            fences2 = GameObject.FindGameObjectsWithTag("Fence2");
        }
        if (fenceUpgrade.fenceLvl == 3)
        {
            fences3 = GameObject.FindGameObjectsWithTag("Fence3");
        }
    }
}