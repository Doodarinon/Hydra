using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float EnemyHealth = 10;
    public float damagePerHit = 0;
    public int attackspeed = 1;

    private float timer;

    public Transform target;
    public LayerMask raycastLayers;
    private NavMeshAgent nav;
    public float SeeDistece = 5f;

    public PlayerHealth playerHealth;
    public Player_Controller playerController;

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
        else
        {


        }
    }



    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Player"))
        {


            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                playerHealth.healthPlayer -= damagePerHit;
                timer = attackspeed;
            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon" && playerController.timer > 1)
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        EnemyHealth -= playerController.damage;
        Debug.Log("took damage");
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}