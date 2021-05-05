using System.Collections;
using System.Collections.Generic;
using AlexM;
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
            navMeshRef = creatureMainRef.navMeshRef;
            //Store all possible targets of type Targer in targetArray
            GameObject currentTarget = FindObjectOfType<HellPortal>().gameObject;
            //Tell the parent what the target is
            if (currentTarget != null)
            {
                creatureMainRef.portalTarget = currentTarget;
                navMeshRef.SetDestination(currentTarget.transform.position);
            }
            else
            {
                Debug.Log("No Portals are Available " + owner);
                Finish();
            }
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
                creatureMainRef.ResetPlanner();
                creatureMainRef.playerTarget = null;
                Finish();
            }
        }
    }
}