using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float lifetime = 5f;
    public float damage;
    void Start()
    {
        Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame

    void OnCollisionEnter(Collision collision)
    {
        // Check what the bullet collided with
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerInfo>().TakeDamage(damage);
            Destroy(gameObject);
            
        }
    
    }
}
