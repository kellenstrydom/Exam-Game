using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrap : MonoBehaviour
{
    public GameObject bulletPrefab;  // The bullet prefab to be shot by the trap
    public Transform spawnPoint;      // The position where the bullets will spawn
    public float shootInterval = 3f;  // Time interval between shots
    private float lastShootTime;      // Time of the last shot

    void Start()
    {
        lastShootTime = Time.time; // Initialize lastShootTime with the current time
    }

    void Update()
    {
        // Check if it's time to shoot
        if (Time.time - lastShootTime >= shootInterval)
        {
            ShootBullet();
            lastShootTime = Time.time; // Update last shoot time
        }
    }

    void ShootBullet()
    {
        // Create a new bullet from the prefab
        GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        // Access the Bullet script component
        projectile bulletScript = newBullet.GetComponent<projectile>();

        // Check if the Bullet script exists on the prefab
        if (bulletScript != null)
        {
            // Set the bullet's velocity to move it forward using the bulletSpeed from the Bullet script
            Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = spawnPoint.forward * bulletScript.bulletSpeed;
        }
    }
}
