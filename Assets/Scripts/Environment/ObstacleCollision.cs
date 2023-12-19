using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charMode1;
    public AudioSource crashSound;
    public GameObject mainCam;
    public GameObject levelControl;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<CharacterMove>().enabled = false;
        charMode1.GetComponent<Animator>().Play("Stumble Backwards");
        crashSound.Play();
        mainCam.GetComponent<Animator>().enabled = true;
        levelControl.GetComponent<EndRun>().enabled = true;
    }
}
