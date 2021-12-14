using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public LayerMask whatIsPlayer;
    public AttackState attackState;
    public float attackRange;
    public bool isInAttackRange;

    public override State RunCurrentState()
    {
        Debug.Log("Made it to chase class.");
        isInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if(isInAttackRange)
        {
            Debug.Log("Now Attacking!");
            return attackState;
        }
        else
        {
            Debug.Log("Finding player!");
            agent.transform.LookAt(player);
            agent.SetDestination(player.transform.position);
            return this; 
        }
    }
}
