using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    public LayerMask whatIsGround, whatIsPlayer;

    public ChaseState chaseState;

    public Vector3 walkPoint;
    public float walkPointRange;
    public float agroRange;
    public bool walkPointSet;
    public bool playerInRange;

    public void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = enemy.GetComponent<NavMeshAgent>();
    }
    public override State RunCurrentState()
    {
        playerInRange = Physics.CheckSphere(transform.position, agroRange, whatIsPlayer);
        if(playerInRange)
        {
            Debug.Log("Now chasing!");
            return chaseState;
        }
        else
        {
            if (!walkPointSet)
            {
                SearchWalkPoint();
            }
            else if (walkPointSet)
            {
                agent.SetDestination(walkPoint);
            }

            Vector3 distToWalkPoint = transform.position - walkPoint;
            if (distToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }
            return this;
        }

        void SearchWalkPoint()
        {
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
            if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            {
                walkPointSet = true;
            }
        }
    }
}
