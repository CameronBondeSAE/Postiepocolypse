using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace RileyMcGowan
{
    public class StalkToPlayer : AntAIPlannerState
    {
        //Public Vars
        
        //Private Vars
        private float safeDistance;
        private GameObject currentTarget;
        private Vector3 targetLocation;
        private int timeToFollow;

        public override void Enter()
        {
            base.Enter();
            targetLocation = creatureMainRef.playerTarget.transform.position;
            navMeshRef.SetDestination(targetLocation);
            timeToFollow = 0;
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            //Take the safeDistance from the main script so all controls are on the main script
            safeDistance = creatureMainRef.safeDistance;

            if (targetLocation != creatureMainRef.playerTarget.transform.position && timeToFollow < 100)
            {
                timeToFollow += 1;
                navMeshRef.SetDestination(creatureMainRef.playerTarget.transform.position);
                targetLocation = creatureMainRef.playerTarget.transform.position;
            }
            
            //Check the distance the creature has until it's finished
            if (navMeshRef.remainingDistance < safeDistance)
            {
                //Do the state machines job for it...
                antAIRef.worldState.BeginUpdate(antAIRef.planner);
                antAIRef.worldState.Set("PlayerReached", true);
                antAIRef.worldState.EndUpdate();
                creatureMainRef.currentPatrolPoint = null;
                //Stop navigation and finish
                Finish();
            }
        }
    }
}