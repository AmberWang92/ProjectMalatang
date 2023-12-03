using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathTrigger : MonoBehaviour
{


    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         Debug.Log("Player just died now!");
    //         //Destroy(other.gameObject);
    //         //RespawnCharacter();
    //         //player.transform.position = respawn_point.transform.position;
    //         GameObject myPlayer = other.gameObject;
    //         myPlayer.GetComponent<CharacterController>().enabled = false;
    //         myPlayer.transform.position = respawn_point.transform.position;
    //         myPlayer.GetComponent<CharacterController>().enabled = true;

    //     }
    // }
    // Function to respawn the character
    // private void RespawnCharacter()
    // {
    //     // Call the RespawnMainCharacter method from the RespawnManager
    //     myRespawnManager.RespawnMainCharacter();
    //     // You might have additional logic here related to player death
    // }


    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float respawnDelay = 3f; // Adjust the delay time as needed

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player just died now!");
            StartCoroutine(RespawnAfterDelay(other.gameObject));
        }
    }

    private IEnumerator RespawnAfterDelay(GameObject player)
    {
        // Disable the CharacterController to prevent movement during the delay
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller != null)
            controller.enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        // Move the player to the respawn point and re-enable the CharacterController
        player.transform.position = respawnPoint.position;

        if (controller != null)
            controller.enabled = true;

        Debug.Log("Player respawned!");

        // You might want to add additional logic or actions after the player respawns here
    }

}