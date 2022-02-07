using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseEnemy_Script : MonoBehaviour
{
    public float speed = 0;
    public int health = 0;
    public int damage = 0;
    public float SeeDistece = 5f;

    public Transform target;
    public LayerMask raycastLayers;
    private NavMeshAgent nav;
   


    // Start is called before the first frame update

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

}

