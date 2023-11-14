using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyData : MonoBehaviour
{
    public float maxHealth = 5f;
    [SerializeField]
    private float currentHealth;

    public float heathOrbDropChance;
    public GameObject healthOrbObj;
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

        if (Random.Range((int)0, (int)100) < heathOrbDropChance)
            Instantiate(healthOrbObj, transform.position, Quaternion.identity);
        Destroy(gameObject,5f);
        gameObject.SetActive(false);
    }
}
