using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime;
    public float damageAmount;

    private void Awake()
    {
        Destroy(gameObject,lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"projectile hit {other.name}");
        if (other.CompareTag("Player"))
        {
            if (other.GetComponentInParent<PlayerInfo>().TakeDamage(damageAmount))
            {
                Destroy(gameObject);
            }        
        }
    }
    
    
}
