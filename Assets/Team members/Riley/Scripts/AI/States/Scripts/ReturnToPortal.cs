using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace RileyMcGowan
{
    public class ReturnToPortal : AntAIPlannerState
    {
        //Public Vars
        
        //Private Vars
        private bool isFinished;
        private float safeDistance;

        public override void Enter()
        {
            base.Enter();
            isFinished = false;
            navMeshRef = creatureMainRef.navMeshRef;
            //GameObject currentTarget = portal object ref?
            //owner.GetComponent<CreatureMain>().portalTarget = currentTarget;
            //navMeshRef.SetDestination(currentTarget.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            safeDistance = creatureMainRef.safeDistance;
            
            //Check the distance the creature has until it's finished
            if (navMeshRef.remainingDistance < safeDistance)
            {
                //Stop navigation and finish
                creatureMainRef.portalTarget = null;
                Finish();
            }
        }
    }
}