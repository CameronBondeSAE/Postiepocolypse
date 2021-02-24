using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

public class RoamingState : AntAIState
{

    public NavMeshAgent navMeshAgent;
    public Transform target;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    //For use with Planner use Override
    public override void Enter()
    {
        base.Enter();
        navMeshAgent.SetDestination(target.position);
    }
}
