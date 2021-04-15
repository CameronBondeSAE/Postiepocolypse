using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace RileyMcGowan
{
    public class Run : AntAIState
    {
        private float safeDistance;
        private NavMeshAgent parentNavMeshAgent;
        public GameObject owner;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
        }
        public override void Enter()
        {
            base.Enter();
            RunTarget[] targetArray = FindObjectsOfType<RunTarget>();
            RunTarget currentTarget = targetArray[Random.Range(0, targetArray.Length)];
            owner.GetComponent<Monster_Main>().currentTarget = currentTarget;
            //Move
            parentNavMeshAgent = owner.GetComponent<NavMeshAgent>();
            parentNavMeshAgent.SetDestination(owner.GetComponent<Monster_Main>().currentTarget.transform.position);
        }
        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            //Take the safeDistance from the main script so all controls are on the main script
            safeDistance = owner.GetComponent<Monster_Main>().safeDistance;
            
            //Check the distance the monster has until it's finished
            if (parentNavMeshAgent.remainingDistance < safeDistance)
            {
                //Stop navigation and finish
                owner.GetComponent<Monster_Main>().currentTarget = null;
                Finish();
            }
        }
    }
}