using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float jumpForce = 10.0f;

    private Rigidbody rb;
    private bool isGrounded = true;
    static public bool canMove = false;
    public GameObject playerObject;
    private bool isJumping = false;
    private Vector3 moveDirection = Vector3.forward;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canMove = true; 
        playerObject.GetComponent<Animator>().Play("Run 0");
        StartCoroutine(ConstantRun());
    }

    void Update()
    {
        MovePlayer();
        CheckJump();
    }

    void MovePlayer()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            moveDirection = new Vector3(horizontalInput, 0.0f, 1.0f).normalized;

            if (isGrounded && !isJumping)
            {
                rb.velocity = moveDirection * moveSpeed;
            }
        }
            
    }

    void CheckJump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
            playerObject.GetComponent<Animator>().Play("Jump");

        }
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
        StartCoroutine(JumpSequence());

    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        isJumping = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        playerObject.GetComponent<Animator>().Play("Run 0");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    IEnumerator ConstantRun()
    {
        yield return new WaitForSeconds(0.1f);
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z) * moveSpeed;
    }

}




