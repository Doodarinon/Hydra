using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWander : MonoBehaviour
{
    public float roamTime;
    public float roamRadius;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (roamTime > 0)
        {
            roamTime -= Time.deltaTime;
        }
        else
        {
            roamTime = Random.Range(5.0f, 15.0f);
            Wander();
        }
    }

    /// <summary>
    /// Enemy randomly wanders around but within a certain radius.
    /// </summary>
    private void Wander()
    {
        // Sends enemy to new random position. Layermask is set to (-1) which means destination can be found on all layers.
        Vector3 newPosition = RandomNavSphere(transform.position, roamRadius, -1);
        agent.SetDestination(newPosition);

        // Rotates enemy while wandering to the direction it's going in.
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    /// <summary>
    /// Vector which calculates a random destination from the current position within a set range.
    /// </summary>
    /// <param name="currentPosition"></param>
    /// <param name="distance"></param>
    /// <param name="layermask"></param>
    /// <returns></returns>
    public static Vector3 RandomNavSphere(Vector3 currentPosition, float distance, int layermask)
    {
        // Calculates a random direction within allowed range.
        Vector3 randomDirection = Random.insideUnitSphere * distance;

        randomDirection += currentPosition;

        // Resulting position.
        NavMeshHit navHit;

        // Checks if destination is found, in that case it returns true.
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
}
