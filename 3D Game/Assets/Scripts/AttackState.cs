using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public LayerMask whatIsPlayer;
    public GameObject projectile;
    public float projectileDamage;
    public ChaseState chaseState;
    public float attackCooldown;
    bool alreadyAttacked;
    public bool playerInAttackRange;
    public float range;

    public override State RunCurrentState()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, range, whatIsPlayer);
        agent.SetDestination(transform.position);
        agent.transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //How we attack
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(resetAttack), attackCooldown);
        }
        if(!playerInAttackRange)
        {
            return chaseState;
        }
        return this;
    }

    public void resetAttack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        alreadyAttacked = false;
    }
}
