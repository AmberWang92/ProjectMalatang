using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;

    private Rigidbody rb;
    private bool isGrounded = true;
    static public bool canMove = false;
    public GameObject playerObject;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        MovePlayer();
        CheckJump();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput).normalized * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + movement);
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
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    IEnumerator AddHorizontalForce()
    {
        yield return new WaitForSeconds(0.1f); 

        if (canMove)
        {
            rb.AddForce(transform.forward * moveSpeed * 0.5f, ForceMode.Impulse); 
        }
    }
}




