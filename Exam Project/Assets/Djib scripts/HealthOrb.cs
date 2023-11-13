using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    public int healAmount = 10;
    public int despawnTime = 30; // Time in seconds before despawning

    void Start()
    {
        StartCoroutine(DespawnAfterTime());
    }

    void Update()
    {
        // Update code if needed
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerInfo healScript = other.gameObject.GetComponent<PlayerInfo>();
            if (healScript != null)
            {
                // Call the Heal method and pass the healAmount as a parameter
                healScript.Heal(healAmount);

                // Destroy the health orb after it's collected
                Destroy(gameObject);
            }
        }
    }

    IEnumerator DespawnAfterTime()
    {
        yield return new WaitForSeconds(despawnTime);

        // Destroy the health orb after the specified time
        Destroy(gameObject);
    }
}
