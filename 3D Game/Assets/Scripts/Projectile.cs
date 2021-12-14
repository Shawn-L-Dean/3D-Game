using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject player;
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform == player.transform)
        {
            player.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
