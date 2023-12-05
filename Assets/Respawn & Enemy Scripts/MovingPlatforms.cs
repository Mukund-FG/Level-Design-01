using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public Transform[] movePoints;
    public float moveSpeed;

    private int currentPointIndex = 0;
    
    void Update()
    {
        MovePlatform();
    }
    void MovePlatform()
    {
        // Check if there are points to move between
        if (movePoints.Length > 0)
        {
            // Get the current target point
            Transform targetPoint = movePoints[currentPointIndex];

            // Move the platform towards the target point
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

            // Check if the platform has reached the target point
            if (transform.position == targetPoint.position)
            {
                // Move to the next target point
                currentPointIndex = (currentPointIndex + 1) % movePoints.Length;
            }
        }
        else
        {
            Debug.LogError("No move points assigned to the platform.");
        }
    }
}

