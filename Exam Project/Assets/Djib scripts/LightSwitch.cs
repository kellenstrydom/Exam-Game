using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject cylinder; // Reference to the cylinder GameObject
    public Light pointLight;    // Reference to the point light GameObject

    private bool isLightOn = false;

    private void Start()
    {
        if (cylinder == null)
        {
            Debug.LogError("Cylinder GameObject is not assigned!");
            enabled = false; // Disable the script
        }

        if (pointLight == null)
        {
            Debug.LogError("Point Light GameObject is not assigned!");
            enabled = false; // Disable the script
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == cylinder)
        {
            // Toggle the light on or off
            isLightOn = !isLightOn;
            pointLight.enabled = isLightOn;

            // Optionally, you can play a sound or add other actions here when the light state changes.
        }
    }
}
  

