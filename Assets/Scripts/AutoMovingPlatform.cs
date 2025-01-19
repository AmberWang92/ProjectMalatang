using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement
    public float leftLimit = -5f; // Left limit of movement
    public float rightLimit = 5f; // Right limit of movement

    private bool movingRight = true;

    void Update()
    {
        // Move the platform left and right within specified limits
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            //Debug.Log("position X" + transform.position.x);

            if (transform.position.x >= rightLimit)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            // Debug.Log("moving left");

            if (transform.position.x <= leftLimit)
            {
                movingRight = true;
            }
        }
    }
}
