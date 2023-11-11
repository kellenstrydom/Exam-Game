using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float damage;
    void Start()
    {
        Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * bulletSpeed;
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
        else
            Destroy(gameObject);
    }
}
