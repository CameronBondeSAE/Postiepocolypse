using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;
using UnityEngine.AI;

public class MonsterScare : MonoBehaviour
{
    public Transform player;
    private Vector3 playerTransform;
    public float distanceToPlayer;
    public bool isScared;
    public Transform playerScareLo;

    //Nav
    public NavMeshAgent monsterNavMesh;
    public float navSafeDistance;

    /// use for setting past location : private bool activeDestination;
    
    //Subscribe to Death
    private void OnEnable()
    {
        GetComponent<healthComponent.HealthComponent>().killObject += OnKillObject;
    }
    private void OnDisable()
    {
        GetComponent<healthComponent.HealthComponent>().killObject -= OnKillObject;
    }
    private void Start()
    {
        monsterNavMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer > navSafeDistance && isScared != true)
        {
            //Constantly sets location
            monsterNavMesh.SetDestination(player.position);
            /// use for setting past location : activeDestination = true;
        }

        if (distanceToPlayer < navSafeDistance)
        {
            //Stops player on distance closed
            monsterNavMesh.SetDestination(transform.position);
            /// use for setting past location : activeDestination = false;
        }

        /*Old code for scaring and moving
        if (isScared == true)
        {
            playerTransform = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            transform.LookAt(playerTransform);
        }
        */
    }

    //Kill our monster
    void OnKillObject(healthComponent.HealthComponent healthComponent)
    {
        Destroy(this);
    }
}
