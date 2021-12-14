using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public GameObject projectile;
    public float projectileDamage;
    public PatrolState patrolState;
    public float attackCooldown;
    bool alreadyAttacked;
    //public bool playerInAttackRange;

    public override State RunCurrentState()
    {
        //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //How we attack
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 6f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(resetAttack), attackCooldown);
        }

        Debug.Log("Attacked player!");
        return patrolState;
    }

    public void resetAttack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        alreadyAttacked = false;
    }
}
