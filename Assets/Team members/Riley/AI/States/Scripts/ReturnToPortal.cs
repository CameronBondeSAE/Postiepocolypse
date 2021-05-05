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
            if (creatureMainRef.vfxComp.GetInt("MaxParticles") > 2000)
            {
                int particalRef;
                particalRef = creatureMainRef.vfxComp.GetInt("MaxParticles") - 10;
                if (particalRef < 2000)
                {
                    particalRef = 2000;
                    creatureMainRef.vfxComp.SetInt("MaxParticles", particalRef);
                }
                else
                {
                    creatureMainRef.vfxComp.SetInt("MaxParticles", particalRef);
                }
            }
            if (creatureMainRef.vfxComp.GetFloat("Radius") > 1)
            {
                float radiusRef;
                radiusRef = creatureMainRef.vfxComp.GetFloat("Radius") - 0.5f;
                if (radiusRef < 1)
                {
                    radiusRef = 1;
                    creatureMainRef.vfxComp.SetFloat("Radius", radiusRef);
                }
                else
                {
                    creatureMainRef.vfxComp.SetFloat("Radius", radiusRef);
                }
            }

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