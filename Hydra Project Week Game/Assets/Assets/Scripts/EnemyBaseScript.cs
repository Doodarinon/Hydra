using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float EnemyHeatlh = 10;
    public float damagePerHit = 0;
    public float attackspeed = 5f;

    private float timer;

    public Transform target;
    public LayerMask raycastLayers;
    private NavMeshAgent nav;
    public float SeeDistece = 5f;

    public PlayerHealth playerHealth;

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

        dead();

        
    }
    public void dead()
    {
        //If Enemys health under 0 
        if(EnemyHeatlh <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //while (collision.collider.CompareTag("Player"))
            
                //Debug.Log("yes");
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    playerHealth.healthPlayer -= damagePerHit;
                }
            
        }
    }
}