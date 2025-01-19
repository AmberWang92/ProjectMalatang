using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;

    public Transform cam;
    private Transform platform;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource playerAudio;
    public AudioClip jumpSound;

    [Header("Particles Settings")]
    public ParticleSystem jumpParticles;

    [Header("Movement Settings")]
    [SerializeField] private float playerSpeed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    [Header("Jump Settings")]
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private Vector3 playerVelocity;
    private bool playerIsGrounded;

    void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (platform != null && controller.isGrounded)
        {
            // Move the character along with the platform by updating its position
            controller.Move(platform.position - transform.position);
        }
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
            Debug.Log("Jumping");
            if (playerIsGrounded)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                jumpParticles.Play();
                //Debug.Log("Jumping");
            }
            else
            {
                Debug.Log("Not Jumping. Player is not grounded.");
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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("MovingPlatform"))
        {
            if (platform == null)
            {
                platform = hit.transform;
                transform.SetParent(platform);
            }
        }
        else
        {
            if (platform != null)
            {
                transform.SetParent(null);
                platform = null;
            }
        }
    }


    // private void OnTriggerExit(Collider other)
    // {
    //     Debug.Log("Jump out from platform!");
    //     // if (other.CompareTag("MovingPlatform"))
    //     // {
    //     //     // Unparent the character from the moving platform when exiting its trigger area
    //     //     transform.SetParent(null);
    //     //     platform = null;
    //     // }
    // }
}


