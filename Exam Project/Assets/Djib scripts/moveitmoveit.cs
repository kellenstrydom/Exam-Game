using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveitmoveit : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 100.0f;

    private float horizontalInput;
    private float verticalInput;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;
        Vector3 moveVelocity = moveDirection * moveSpeed;
        rb.velocity = moveVelocity;
    }

    private void Rotate()
    {
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 lookDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
