using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

namespace RileyMcGowan
{
    public class CreatureMain : MonoBehaviour
    {
        //Private Vars
        private Rigidbody rb;
        private RaycastHandler childRaycastHandler;
        private CreatureDamage childHaveDamaged;
        private AntAIAgent antAIRef;
        private Damien.FOV currentFOV;
        private VisualEffect vfxComp;

        //Public Vars
        public GameObject portalTarget;
        public GameObject playerTarget;
        public GameObject currentPatrolPoint;
        public GameObject currentWaterTarget;
        public float floatingHeight;
        public NavMeshAgent navMeshRef;
        public float safeDistance = 1f;
        
        
        void Start()
        {
            //Grab all the components needed for reference
            if (GetComponentInChildren<VisualEffect>() != null)
            {
                vfxComp = GetComponentInChildren<VisualEffect>();
                vfxComp.SetFloat("ParticleSpawnRate", 0.5f); //vfx.setfloat("Name", number);
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
        
        private void FixedUpdate()
        {
            //Raycast leveling
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
        
        
    }
}