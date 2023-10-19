using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour
{
    public Transform target; // The player's transform
    public float height = 10.0f; // The height of the camera above the player
    public float distance = 10.0f; // The distance from the player
    public float smoothSpeed = 5.0f;

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position - Vector3.forward * distance + Vector3.up * height;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Make the camera look at the player
        transform.LookAt(target);
    }
}
