using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;
    public float heightAbovePlayer = 10f; 

    void LateUpdate()
    {
        if (player != null)
        {
            
            Vector3 cameraPosition = player.position + new Vector3(0, heightAbovePlayer, 0);
            transform.position = cameraPosition;

            
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
}
