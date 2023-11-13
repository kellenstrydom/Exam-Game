using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMove : MonoBehaviour
{
    public GameObject movingPlatform; // Reference to the moving platform

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ElectricHitBox"))
        {
            Debug.Log("Hitttt");
            // Start moving the platform when the attack hitbox collides with the generator
            if (movingPlatform != null)
            {
                CableCar platformScript = movingPlatform.GetComponent<CableCar>();
                if (platformScript != null)
                {
                    platformScript.StartMoving(); // Call the StartMoving method on the platform script
                }
                else
                {
                    Debug.LogError("MovingPlatformScript not found on the moving platform GameObject.");
                }
            }
            else
            {
                Debug.LogError("Moving platform GameObject not assigned to the Generator script.");
            }
        }
    }
}
