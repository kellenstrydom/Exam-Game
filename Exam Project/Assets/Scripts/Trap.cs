using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float damage;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.GetComponent<Animator>().Play("Spike");
            PlayerInfo player = collision.transform.GetComponent<PlayerInfo>();
            Debug.Log("Player takes damage");
            if (player != null)
            {
              player.TakeDamage(damage);
            }
          
    
        }
      
    }
}
