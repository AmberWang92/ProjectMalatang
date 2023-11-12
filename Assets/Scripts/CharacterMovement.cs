using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    [Header("Movement Settings")]
    public float playerSpeed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [Header("Jump Settings")]
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    private Vector3 playerVelocity;
    private bool playerIsGrounded;



    // Update is called once per frame
    void Update()
    {
       
        UpdateCharacter();
    }


    private void UpdateCharacter()
    {
        playerIsGrounded = controller.isGrounded;
        if (playerIsGrounded)
        {
            playerVelocity.y = 0f;
        }

        Move();

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump"))
        {
            if (playerIsGrounded)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                Debug.Log("Jumping");
            }
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);

        }
    }
}

