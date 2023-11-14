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

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        other.gameObject.GetComponentInParent<PlayerInfo>().Heal(healAmount);
        Debug.Log("heal");
        Destroy(gameObject);
    }

    IEnumerator DespawnAfterTime()
    {
        yield return new WaitForSeconds(despawnTime);

        // Destroy the health orb after the specified time
        Destroy(gameObject);
    }
}
