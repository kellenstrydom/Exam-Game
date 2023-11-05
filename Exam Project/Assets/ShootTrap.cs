using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrap : MonoBehaviour
{
    [SerializeField] private float timer = 5;
    private float bulletTimer;

    public GameObject trapBullet;
    public Transform spawnPoint;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        { 
            PlayerInfo player = collision.transform.GetComponent<PlayerInfo>();
            Debug.Log("Player takes damage");
            ShootAtPlay();
            if (player != null)
            {
             //   player.TakeDamage(damage);
            }


        }

    }

    private void ShootAtPlay()
    {
        bulletTimer -= Time.deltaTime;

        if (bulletTimer > 0) return;

        bulletTimer = timer;

        GameObject bulletObj = Instantiate(trapBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * bulletSpeed);
        Destroy(bulletObj, 5f);
    }
}
