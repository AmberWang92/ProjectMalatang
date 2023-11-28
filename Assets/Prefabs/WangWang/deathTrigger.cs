using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathTrigger : MonoBehaviour
{
    public RespawnManager myRespawnManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player just died!");
            Destroy(other.gameObject);
            RespawnCharacter();
        }
    }
    // Function to respawn the character
    private void RespawnCharacter()
    {
        // Call the RespawnMainCharacter method from the RespawnManager
        myRespawnManager.RespawnMainCharacter();
        // You might have additional logic here related to player death
    }

}