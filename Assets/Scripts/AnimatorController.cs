using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private bool playerIsDead;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        // Check if the player is dead
        if (!playerIsDead)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                animator.SetBool("IsRunning", true);
            }
            else
            {
                animator.SetBool("IsRunning", false);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("IsJumping", true);
            }
            else
            {
                animator.SetBool("IsJumping", false);
            }
        }
        if (playerIsDead)
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsJumping", false);

            // Start the coroutine for the delay before transitioning to the idle animation
            StartCoroutine(RestartAfterDelay(3f)); // 3 seconds delay before restarting
        }
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Floor"))
    //     {
    //         Debug.Log("Player touched the floor!");
    //         // Trigger the animation when the player touches the floor
    //         animator.SetTrigger("IsFalling");
    //         playerIsDead = true;
    //     }
    // }

    private IEnumerator RestartAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Transition to the idle animation after the delay
        animator.SetTrigger("Idle"); // Replace "Idle" with the appropriate trigger for your idle animation
        playerIsDead = false; // Reset player's death state
    }

}
