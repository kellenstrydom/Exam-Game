using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public float maxHealth = 5f;
    [SerializeField]
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        if (currentHealth <= 0) return;
        
        currentHealth -= damage;
        Debug.Log($"{name} took {damage} dmg");
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>().KillEnemy();
        
        Destroy(gameObject,5f);
        gameObject.SetActive(false);
    }
}
