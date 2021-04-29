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
        private float safeDistance;

        public override void Enter()
        {
            base.Enter();
            creatureMainRef.currentWaterTarget = null;
            navMeshRef = creatureMainRef.navMeshRef;
            //Store all possible targets of type Targer in targetArray
            GameObject currentTarget = FindObjectOfType<DummyPortal>().gameObject; //HACK CHANGE LATER FOR MAIN PORTALS
            //Tell the parent what the target is
            creatureMainRef.portalTarget = currentTarget;
            navMeshRef.SetDestination(currentTarget.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            safeDistance = creatureMainRef.safeDistance;
            
            //Check the distance the creature has until it's finished
            if (navMeshRef.remainingDistance < safeDistance)
            {
                antAIRef.worldState.BeginUpdate(antAIRef.planner);
                antAIRef.worldState.Set("EnergyDeposited", true);
                antAIRef.worldState.EndUpdate();
                //Stop navigation and finish
                creatureMainRef.portalTarget = null;
                Finish();
            }
        }
    }
}