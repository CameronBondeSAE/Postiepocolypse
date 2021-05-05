using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Mirror;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

namespace RileyMcGowan
{
    public class CreatureMain : NetworkBehaviour
    {
        //Private Vars
        private Rigidbody rb;
        private RaycastHandler childRaycastHandler;
        private CreatureDamage childHaveDamaged;
        private AntAIAgent antAIRef;
        private Damien.FOV currentFOV;
        private bool colourHasSwapped;
        

        //Public Vars
        public GameObject portalTarget;
        public GameObject playerTarget;
        public GameObject currentPatrolPoint;
        public GameObject currentWaterTarget;
        public float floatingHeight;
        public NavMeshAgent navMeshRef;
        public float safeDistance = 1f;
        public VisualEffect vfxComp;
        public bool swapColour;
        
        
        void Start()
        {
            swapColour = false;
            //Grab all the components needed for reference
            if (GetComponentInChildren<VisualEffect>() != null)
            {
                //Grab all the components needed for reference
                if (GetComponentInChildren<VisualEffect>() != null)
                {
                    vfxComp = GetComponentInChildren<VisualEffect>();
                    vfxComp.SetFloat("ParticleSpawnRate", 0.5f); //vfx.setfloat("Name", number);
                    vfxComp.SetFloat("Radius", 1f);
                    vfxComp.SetInt("MaxParticles", 2000);
                }
                if (GetComponentInChildren<CreatureDamage>() != null)
                {
                    childHaveDamaged = GetComponentInChildren<CreatureDamage>();
                }
                if (GetComponent<Rigidbody>() != null)
                {
                    rb = GetComponent<Rigidbody>();
                }
                if (GetComponentInChildren<RaycastHandler>() != null)
                {
                    childRaycastHandler = GetComponentInChildren<RaycastHandler>();
                }
                if (GetComponent<AntAIAgent>() != null)
                {
                    antAIRef = GetComponent<AntAIAgent>();
                }
                if (GetComponent<NavMeshAgent>() != null)
                {
                    navMeshRef = GetComponent<NavMeshAgent>();
                }
                if (GetComponent<Damien.FOV>() != null)
                {
                    currentFOV = GetComponent<Damien.FOV>();
                }
                ResetPlanner();
            }
            
        }
        
        private void FixedUpdate()
        {
            vfxComp.SetFloat("ParticleSpawnRate", Random.Range(0.0f, 0.5f));
            //Raycast leveling
            if (swapColour != true && colourHasSwapped != true)
            {
                colourHasSwapped = true;
                Gradient defaultColour = vfxComp.GetGradient("DefaultColour");
                vfxComp.SetGradient("ActiveColour", defaultColour);
            }
            else if (swapColour != false && colourHasSwapped != false)
            {
                colourHasSwapped = false;
                Gradient angryColour = vfxComp.GetGradient("EnemySpottedColour");
                vfxComp.SetGradient("ActiveColour", angryColour);
            }

            if (childRaycastHandler.distanceToPlatformInfo > floatingHeight && childRaycastHandler != null)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
            }
            else
            {
                if (childRaycastHandler.distanceToPlatformInfo != floatingHeight && childRaycastHandler != null)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
                }
            }
            
            //Check the FOV for a player target
            if (currentFOV.listOfTargets.Count > 0)
            {
                playerTarget = currentFOV.listOfTargets[0];
            }
            
            //Check if the object should be moving
            if (playerTarget != null || currentWaterTarget != null || currentPatrolPoint != null || portalTarget != null)
            {
                navMeshRef.isStopped = false;
            }
            else
            {
                navMeshRef.isStopped = true;
            }
            
            //Planner do we have a player target
            if (playerTarget != null && antAIRef != null)
            {
                antAIRef.SetGoal("ReturnToPortal");
            }
            else
            {
                antAIRef.SetGoal("PatrolLoop");
            }
        }

        public void ResetPlanner()
        {
            antAIRef.worldState.BeginUpdate(antAIRef.planner);
            antAIRef.worldState.Set("PlayerReached", false);
            antAIRef.worldState.Set("EnergyCollected", false);
            antAIRef.worldState.Set("EnergyDeposited", false);
            antAIRef.worldState.Set("PatrolCompleted", false);
            antAIRef.worldState.EndUpdate();
        }
        
        //CollectEnergy
        public void StartCollectEnergy()
        {
            StartCoroutine(CollectEnergy());
        }

        IEnumerator CollectEnergy()
        {
            Gradient energyColour = vfxComp.GetGradient("EnergyCollect");
            vfxComp.SetGradient("ActiveColour", energyColour);
            yield return new WaitForSeconds(5);
            antAIRef.worldState.BeginUpdate(antAIRef.planner);
            antAIRef.worldState.Set("EnergyCollected", true);
            antAIRef.worldState.EndUpdate();
            currentWaterTarget = null;
            GetComponentInChildren<CollectEnergy>().Finish();
        }
    }
}