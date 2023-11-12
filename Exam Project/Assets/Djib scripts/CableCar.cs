using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableCar : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float movementSpeed = 5.0f;
    public float stopDuration = 2.0f; // Adjust this to control how long the cable car stops at each point

    private float currentStopTime = 0.0f;
    private bool isMovingForward = true;

    private void Update()
    {
        MoveCableCar();
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
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, movementSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPoint.position) < 0.01f)
            {
                currentStopTime += Time.deltaTime;

                if (currentStopTime >= stopDuration)
                {
                    isMovingForward = true;
                    currentStopTime = 0.0f;
                }
            }
        }
    }
}
