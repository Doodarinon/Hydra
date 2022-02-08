using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float EnemyHeatlh = 10;
    public float Damage = 0;


    public Transform target;
    public LayerMask raycastLayers;
    private NavMeshAgent nav;
    public float SeeDistece = 5f;
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

        Dead();
    }
    public void Dead()
    {
        if(EnemyHeatlh <= 0)
        {
            Destroy(gameObject);
        }
    }

}