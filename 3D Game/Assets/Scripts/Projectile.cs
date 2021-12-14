using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject player;
    public float damage = 20f;
    public float timeActive = 1.5f;

    private void Start()
    {
        Invoke("Delete", timeActive);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(player != null && collision.gameObject.tag.Equals("Player"))
        {
            player.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}
