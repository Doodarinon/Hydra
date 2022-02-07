using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public float sightDistance = 5;
    public Transform target;
    private NavMeshAgent nav;
    private Animator animator;
    public LayerMask raycastLayer;
    private LineRenderer lineRenderer;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RaycastHit hit;
        if (!Physics.Linecast(transform.position + Vector3.up, target.position, out hit, raycastLayer))
        {   
            //if in range, move to target
            if(Vector3.Distance(transform.position + Vector3.up, target.position) < sightDistance )
           
                nav.destination = target.position;
            lineRenderer.SetPosition(1, transform.position + Vector3.up);
        }

        else
        {
            lineRenderer.SetPosition(1, hit.point);
            nav.destination = target.position;
        }

        animator.SetFloat("move", nav.velocity.magnitude);

        //drawline
      
        
    }
}
