using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float bulletSpeed = 10f;
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
            // Handle enemy hit (e.g., deal damage, apply effects)
            // You can access the collided enemy object using collision.gameObject
        }
        else

       
        Destroy(gameObject);
    }
}
