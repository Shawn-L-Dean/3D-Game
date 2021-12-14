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
        isInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if(isInAttackRange)
        {
            return attackState;
        }
        else
        {
            agent.transform.LookAt(player);
            agent.SetDestination(player.transform.position);
            return this; 
        }
    }
}
