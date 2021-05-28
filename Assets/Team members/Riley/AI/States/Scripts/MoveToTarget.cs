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
        private bool _isFinished;
        private float _safeDistance;
        private GameObject currentTarget;
        private Vector3 targetLocation;

        public override void Enter()
        {
            base.Enter();
            _isFinished = false;
            navMeshRef = creatureMainRef.navMeshRef;
            currentTarget = creatureMainRef.currentPatrolPoint;
            targetLocation = currentTarget.transform.position;
            navMeshRef.SetDestination(targetLocation);
            Gradient defaultColour = creatureMainRef.vfxComp.GetGradient("DefaultColour");
            creatureMainRef.vfxComp.SetGradient("ActiveColour", defaultColour);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (creatureMainRef.vfxComp.GetInt("MaxParticles") < 3000)
            {
                int particalRef;
                particalRef = creatureMainRef.vfxComp.GetInt("MaxParticles") + 500;
                creatureMainRef.vfxComp.SetInt("MaxParticles", particalRef);
            }
            if (creatureMainRef.vfxComp.GetFloat("Radius") < 2f)
            {
                float radiusRef;
                radiusRef = creatureMainRef.vfxComp.GetFloat("Radius") + 0.5f;
                creatureMainRef.vfxComp.SetFloat("Radius", radiusRef);
            }
            
            if (energyRef.CurrentAmount < energyRef.MaxAmount / 4 && creatureMainRef.energyCollecting != true)
            {
                GameObject playerFake = owner;
                creatureMainRef.playerTarget = playerFake;
            }

            if (creatureMainRef.playerTarget != null)
            {
                Finish();
            }
            //Take the safeDistance from the main script so all controls are on the main script
            _safeDistance = creatureMainRef.safeDistance;
            
            //Check the distance the creature has until it's finished
            if (creatureMainRef.currentPatrolPoint && owner != null)
            {
                if (Vector3.Distance(owner.transform.position, creatureMainRef.currentPatrolPoint.transform.position) < _safeDistance)
                {
                    //Stop navigation and finish
                    creatureMainRef.currentPatrolPoint = null;
                    antAIRef.worldState.BeginUpdate(antAIRef.planner);
                    antAIRef.worldState.Set("TargetFound", false);
                    antAIRef.worldState.EndUpdate();
                    Finish();
                }
            }
        }
    }
}