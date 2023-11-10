using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light lampLight;
    public float intensityIncrease = 1.0f; // Adjust this value to control the rate of intensity increase

    private void Start()
    {
        lampLight.intensity = 0.0f; // Start with a dim light
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ElectricHitBox")) // Check if it's the player's collider
        {
            StartCoroutine(IncreaseIntensityOverTime());
        }
    }

    IEnumerator IncreaseIntensityOverTime()
    {
        while (lampLight.intensity < 1.0f) // You can adjust this value as needed (1.0f is the maximum intensity)
        {
            lampLight.intensity += intensityIncrease * Time.deltaTime;
            yield return null;
        }
    }
}
  

