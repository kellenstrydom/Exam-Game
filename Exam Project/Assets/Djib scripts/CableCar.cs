using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableCar : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float movementSpeed = 5.0f;
    public float stopDuration = 2.0f;

    private float currentStopTime = 0.0f;
    public bool isMovingForward = false;

    private void Update()
    {
        MoveCableCar();
    }

    public void StartMoving()
    {
        isMovingForward = true;
    }

    private void MoveCableCar()
    {
        if (isMovingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, movementSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, endPoint.position) < 0.01f)
            {
                currentStopTime += Time.deltaTime;

                if (currentStopTime >= stopDuration)
                {
                    isMovingForward = false;
                    currentStopTime = 0.0f;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
