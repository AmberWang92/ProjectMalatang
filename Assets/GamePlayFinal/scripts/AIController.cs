using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    NavMeshAgent agent;
    PlayerCharacter1 character;
    Transform player;

    
    void Start()
    {
        character = GetComponent<PlayerCharacter1>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;


        InvokeRepeating("FireControl",1, 3);
    }

    void FireControl()
    {
        character.Attack();
    }

    void Update()
    {
        agent.destination = player.position;
        transform.LookAt(player.transform);
    }
}
