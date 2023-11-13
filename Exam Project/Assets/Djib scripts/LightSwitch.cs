using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light lampLight;
    public float intensityIncrease = 4.0f; // Adjust this value to control the rate of intensity increase
    public bool isLightOn;
    
    private void Start()
    {
        lampLight.intensity = 0.0f; // Start with a dim light
        isLightOn = false; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isLightOn) return;
        
        if (other.CompareTag("ElectricHitBox")) // Check if it's the player's collider
        {
            LightLamp();
        }
    }

    public void LightLamp(bool objective = true)
    {
        if (isLightOn) return;
        
        StartCoroutine(IncreaseIntensityOverTime());
        isLightOn = true;
        //GetComponent<Outline>().enabled = false;
        
        if (objective)
            GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>().LightLamp();

    }

    IEnumerator IncreaseIntensityOverTime()
    {
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * 1/.5f;
            if (t > 1) t = 1;
            lampLight.intensity = Mathf.Lerp(0, intensityIncrease, t);
            yield return null;
        }
        
        // while (lampLight.intensity < 1.0f) // You can adjust this value as needed (1.0f is the maximum intensity)
        // {
        //     lampLight.intensity += intensityIncrease * Time.deltaTime*3;
        //     yield return null;
        // }
    }
}
  

