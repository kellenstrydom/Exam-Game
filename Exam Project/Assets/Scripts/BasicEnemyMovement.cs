using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemyMovement : MonoBehaviour
{
    

    public float movementSpeed = 3f;

    private Transform target;

    public float maxOffset = 0.5f;
    private Vector3 offset;
    private Rigidbody rb;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        
        
        offset = new Vector3(Random.Range(-maxOffset, maxOffset), 0, Random.Range(-maxOffset, maxOffset));
    }

    private void Update()
    {
        if (target != null)
        {
            
            Vector3 direction = (target.position + offset - transform.position).normalized;

           
            transform.Translate(direction * (movementSpeed * Time.deltaTime));
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int randomDamage = Random.Range(1, 6);

           
        }
    }
}
