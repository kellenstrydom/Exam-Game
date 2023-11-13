using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class PlayerInfo : MonoBehaviour
{
    public PlayerControls _playerControls;
    private LevelManager _levelManager;
    public GameObject bloodEffect;
    public Transform closestGen;

    public float currency;
    
    [Header("Health")]
    public float healthPoints;
    public static float MaxHealthPoints = 5;
    
    [Header("Charge")]
    public float charge;
    public static float MaxCharge = 5;
    public static float RechargeRate = .5f;

    

    private void Start()
    {
        ResetStats();

        
        _levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
        _playerControls = GetComponent<PlayerControls>();
    }

    private void Update()
    {
        if (charge < MaxCharge)
        {
            charge += RechargeRate * Time.deltaTime;
            if (charge > MaxCharge)
            {
                charge = MaxCharge;
            }
        }
        
        FindClosestGen();
    }

    void FindClosestGen()
    {
        Debug.Log("look at gen");
        Transform target;
        if (_levelManager.generators.Count == 0)
        {
            target = _levelManager.endPoint;
        }        
        else
        {
            target = _levelManager.generators[0];
            foreach (var gen in _levelManager.generators)
            {
                if (Vector3.Distance(transform.position, gen.position) <
                    Vector3.Distance(transform.position, target.position))
                {
                    target = gen;
                }
            }
        }
        closestGen.up = new Vector3(target.position.x - transform.position.x, target.position.z - transform.position.z,0).normalized;
    }

    public bool UseCharge(float amount)
    {
        if (charge < amount)
            return false;

        charge -= amount;
        return true;
    }

    public bool TakeDamage(float damageAmount, bool dashable = true)
    {
        if (dashable && _playerControls.currentState == PlayerControls.ActionState.dashing)
        {
            Debug.Log("Damage dashed through");
            return false;
        }
        
        healthPoints -= damageAmount;
        GameObject effect = Instantiate(bloodEffect, transform.position + new Vector3(0, 1, 0),Quaternion.identity);
        Destroy(effect,1f);
        Debug.Log($"player took {damageAmount} damage. {healthPoints}hp remaining");

        if (healthPoints <= 0)
        {
            Death();
        }

        return true;
    }

    void Death()
    {
        // death
        _levelManager.PlayerDeath();
        Debug.Log("dead");
    }

    public bool UpgradeMaxHealth(float cost, float increaseAmount = 1)
    {
        if (cost > currency) return false;
        
        currency -= cost;

        MaxHealthPoints += increaseAmount;
        healthPoints += increaseAmount;

        return true;
    }
    
    public bool UpgradeMaxCharge(float cost, float increaseAmount = 1)
    {
        if (cost > currency) return false;
        
        currency -= cost;

        MaxCharge += increaseAmount;
        charge += increaseAmount;
        
        return true;
    }
    
    public bool UpgradeRechargeRate(float cost, float increaseAmount = 0.1f)
    {
        if (cost > currency) return false;
        
        currency -= cost;

        RechargeRate += increaseAmount;
        
        return true;
    }

    public void Heal(float healAmount)
    {
        healthPoints += healAmount;
        if (healthPoints > MaxHealthPoints) healthPoints = MaxHealthPoints;
    }

    public void Respawn(Vector3 pos)
    {
        transform.position = pos;
        ResetStats();
    }

    public void ResetStats()
    {
        healthPoints = MaxHealthPoints;
        charge = MaxCharge;
    }
}
