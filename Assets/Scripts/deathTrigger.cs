using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

class deathTrigger : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float respawnDelay = 3f; // Adjust the delay time as needed
    public TMP_Text countdownTimer;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player just died now!");
            StartCoroutine(RespawnAfterDelay(other.gameObject));
            countdownTimer.enabled = true;
            StartCoroutine(UpdateText());
        }
    }

    private IEnumerator UpdateText()
    {
        while (respawnDelay > 0)
        {
            countdownTimer.text = "Wait for " + respawnDelay + " seconds";
            yield return new WaitForSeconds(1);
            respawnDelay--;
        }
        respawnDelay = 3f;
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

        countdownTimer.enabled = false;
        Debug.Log("Player respawned!");

        // You might want to add additional logic or actions after the player respawns here
    }

}