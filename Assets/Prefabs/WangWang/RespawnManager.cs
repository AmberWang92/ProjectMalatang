using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject mainCharacterPrefab;
    public Transform respawnPoint; // Set the respawn location in the Inspector

    // Function to respawn the main character
    public void RespawnMainCharacter()
    {
        // Instantiate a new instance of the main character prefab at the respawn location
        GameObject newMainCharacter = Instantiate(mainCharacterPrefab, respawnPoint.position, respawnPoint.rotation);
        // You might need to initialize or set up any specific attributes or properties here for the character
    }
}
