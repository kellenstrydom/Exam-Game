using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInfo : MonoBehaviour
{
    public PlayerControls _playerControls;

    public float currency;
    
    [Header("Health")]
    public float HealthPoints;
    public float MaxHealthPoints;
    
    [Header("Charge")]
    public float charge;
    public float maxCharge;
    public float rechargeRate;

    

    private void Start()
    {
        HealthPoints = MaxHealthPoints;
        charge = maxCharge;

        _playerControls = GetComponent<PlayerControls>();
    }

    private void Update()
    {
        if (charge < maxCharge)
        {
            charge += rechargeRate * Time.deltaTime;
            if (charge > maxCharge)
            {
                charge = maxCharge;
            }
        }
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
        
        HealthPoints -= damageAmount;
        Debug.Log($"player took {damageAmount} damage. {HealthPoints}hp remaining");

        if (HealthPoints <= 0)
        {
            Death();
        }

        return true;
    }

    void Death()
    {
        // death
        Debug.Log("dead");
    }

    public bool UpgradeMaxHealth(float cost, float increaseAmount = 1)
    {
        if (cost > currency) return false;
        
        currency -= cost;

        MaxHealthPoints += increaseAmount;
        HealthPoints += increaseAmount;

        return true;
    }
    
    public bool UpgradeMaxCharge(float cost, float increaseAmount = 1)
    {
        if (cost > currency) return false;
        
        currency -= cost;

        maxCharge += increaseAmount;
        charge += increaseAmount;
        
        return true;
    }
    
    public bool UpgradeRechargeRate(float cost, float increaseAmount = 0.1f)
    {
        if (cost > currency) return false;
        
        currency -= cost;

        rechargeRate += increaseAmount;
        
        return true;
    }
}
