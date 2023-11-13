using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorElectricity : MonoBehaviour
{
    public bool isPowered;

    [Header("Lamps connected")] 
    public List<LightSwitch> lampsConnected;
    private void Start()
    {
        isPowered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPowered) return;
        
        if (other.CompareTag("ElectricHitBox")) // Check if it's the player's collider
        {
            PowerGenerator();
        }
    }

    private void PowerGenerator()
    {
        GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>().PowerGenerator(transform);
        isPowered = true;
        
        GetComponent<Outline>().enabled = false;

        foreach (var lamp in lampsConnected)
        {
            lamp.LightLamp();
        }
    }
}
