using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace RileyMcGowan
{
    public class MoveToTarget : AntAIPlannerState
    {
        //Public Vars
        
        //Private Vars
        private bool isFinished;
        private float safeDistance;
        private GameObject currentTarget;
        private Vector3 targetLocation;

        public override void Enter()
        {
            base.Enter();
            isFinished = false;
            navMeshRef = creatureMainRef.navMeshRef;
            currentTarget = creatureMainRef.currentPatrolPoint;
            targetLocation = currentTarget.transform.position;
            navMeshRef.SetDestination(targetLocation);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (creatureMainRef.playerTarget != null)
            {
                Finish();
            }
            //Take the safeDistance from the main script so all controls are on the main script
            safeDistance = creatureMainRef.safeDistance;
            
            //Check the distance the creature has until it's finished
            if (navMeshRef.remainingDistance < safeDistance)
            {
                //Stop navigation and finish
                creatureMainRef.currentPatrolPoint = null;
                Finish();
            }
        }
    }
}