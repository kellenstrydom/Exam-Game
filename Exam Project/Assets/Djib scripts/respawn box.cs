using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnbox : MonoBehaviour
{
    public Transform respawnPoint;
  
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        // Teleport the player to the respawn point
        player.transform.position = respawnPoint.position;
        // You may also want to add additional respawn logic here, such as resetting player health or other properties.
    }
}
