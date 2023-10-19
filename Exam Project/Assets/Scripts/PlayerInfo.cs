using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
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
}
