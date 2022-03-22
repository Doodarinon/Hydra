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
    public float damageTimer;
    public int counter;

    private float timer;
    private int fenceAmmount;
    private float wanderSpeed = 0.5f;
    private float seeDistance = 25f;

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
    public Fence_Upgrade fenceUpgrade;
    public HealthBar healthBar;
    public NavMeshAgent nav;
    public Transform target;
    void Start()
    {
        playerController = FindObjectOfType<Player_Controller>().GetComponent<Player_Controller>();
        bunkerScript = FindObjectOfType<Bunker_Script>().GetComponent<Bunker_Script>();
        playerHealth = FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
        enemySpawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();
        healthBar = FindObjectOfType<HealthBar>().GetComponent<HealthBar>();
        fenceUpgrade = FindObjectOfType<Fence_Upgrade>().GetComponent<Fence_Upgrade>();
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
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
        bunker = GameObject.FindGameObjectsWithTag("Bunker");
        if (fenceUpgrade.fenceLvl == 1 && fences1[0] != null) // Replace "True" with check that cheacks what lvl fences are in the 3 below
        {
            counter = 0;
            closestFence1 = fences1[counter];
            foreach (GameObject temp in fences1)
            {
                if (Vector3.Distance(transform.position, closestFence1.transform.position) > Vector3.Distance(transform.position, fences1[counter].transform.position))
                {
                    closestFence1 = fences1[counter];
                }
                counter++;
            }
        }
        if (fenceUpgrade.fenceLvl == 2 && fences2[0] != null)
        {
            counter = 0;
            closestFence2 = fences2[counter];
            foreach (GameObject temp in fences2)
            {
                if (Vector3.Distance(transform.position, closestFence2.transform.position) > Vector3.Distance(transform.position, fences2[counter].transform.position))
                {
                    closestFence2 = fences2[counter];
                }
                counter++;
            }
        }
        if (fenceUpgrade.fenceLvl == 3 && fences3[0] != null)
        {
            counter = 0;
            closestFence3 = fences3[counter];
            foreach (GameObject temp in fences3)
            {
                if (Vector3.Distance(transform.position, closestFence3.transform.position) > Vector3.Distance(transform.position, fences3[counter].transform.position))
                {
                    closestFence3 = fences3[counter];
                }
                counter++;
            }
        }
        if (closestFence1 != null && closestFence2 != null && closestFence3 != null)
        {
            if (Vector3.Distance(transform.position, closestFence1.transform.position) < Vector3.Distance(transform.position, closestFence2.transform.position) && Vector3.Distance(transform.position, closestFence1.transform.position) < Vector3.Distance(transform.position, closestFence3.transform.position))
            {
                closestFence = closestFence1;
            }
            else if (Vector3.Distance(transform.position, closestFence2.transform.position) < Vector3.Distance(transform.position, closestFence3.transform.position))
            {
                closestFence = closestFence2;
            }
            else
            {
                closestFence = closestFence3;
            }
        }
        try
        {
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
        catch (System.Exception)
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
                //healthBar.SetHealth(playerHealth.currentPlayerHealth);

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

        if (other.CompareTag("Weapon") && damageTimer <= 0 && playerController.timer > 0)
        {
            damageTimer = playerController.timer;
            TakeDamage();
        }
    }
    public void FenceUpgradeChecker()
    {
        Debug.Log("Works");
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