using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light lampLight;
    private bool isOn = false;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ElectricHitBox")) // Check if it's the player's collider
        {
            isOn = !isOn; // Toggle the light state
            lampLight.enabled = isOn; // Enable or disable the light
        }
    }
}
  

