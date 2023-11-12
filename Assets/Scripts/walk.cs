using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5.0f;   // Movement speed
    public float turnSpeed = 10.0f;  // Rotation speed

    [Header("Jump Settings")]
    public float jumpForce = 7.0f;   // Jump force
    public LayerMask groundLayer;    // Layer for detecting ground

    private bool isGrounded;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        

        // Handle movement
        //Move();
        MoveAlternative();

        // Check if the character is grounded
        isGrounded = IsGrounded();

        // Handle jumping
        Jump();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction relative to the camera
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f; // Ignore vertical camera movement
        cameraForward.Normalize();

        Vector3 movement = (cameraForward * verticalInput + Camera.main.transform.right * horizontalInput).normalized * moveSpeed * Time.deltaTime;

        // Apply movement using transform
        transform.Translate(movement);

        // Rotate the character to face the movement direction
        if (movement.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }

    private void MoveAlternative()
    {
        float horizontalInputAbs = Mathf.Abs(Input.GetAxis("Horizontal"));
        float verticalInputAbs = Mathf.Abs(Input.GetAxis("Vertical"));

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        Vector3 movementAbs = new Vector3(horizontalInputAbs, 0f, verticalInputAbs) * moveSpeed * Time.deltaTime;

        Debug.DrawRay(transform.position + new Vector3(0,1,0), movement * 30, Color.red);

        // Move the character
        transform.Translate(movementAbs);

        // Rotate the character to face the movement direction
        if (movementAbs.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Apply a jump force (you may need to adjust this depending on your setup)
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    private bool IsGrounded()
    {
        // Check if the character is grounded using a simple raycast
        RaycastHit hit;
        float rayLength = 0.1f;

        //Debug.Log("Inside function IsGrounded");
        //Debug.DrawRay(transform.position, new Vector3(0, -rayLength, 0), Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength, groundLayer))
        {
            return true;
        }

        return false;
    }
}
