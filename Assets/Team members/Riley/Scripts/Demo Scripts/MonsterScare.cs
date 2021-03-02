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
    public bool inVision;

    //Nav
    public NavMeshAgent monsterNavMesh;
    public float navSafeDistance;

    /// use for setting past location : private bool activeDestination;
    
    //Subscribe to Death
    private void OnEnable()
    {
        GetComponent<RileyMcGowan.Health>().killObject += OnKillObject;
    }
    private void OnDisable()
    {
        GetComponent<RileyMcGowan.Health>().killObject -= OnKillObject;
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
            ///Can be used for setting past location : activeDestination = false;
        }

        ///Code to linecast
        if (Physics.Linecast(transform.position, player.position))
        {
            inVision = false;
        }
        else
        {
            inVision = true;
        }
        ///Code to linecast
        
        /*Old code for scaring and moving
        if (isScared == true)
        {
            playerTransform = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            transform.LookAt(playerTransform);
        }
        */
    }

    //Kill our monster
    void OnKillObject(RileyMcGowan.Health health)
    {
        Destroy(gameObject);
    }
}
