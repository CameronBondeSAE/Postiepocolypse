﻿using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

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
        
        //Public Vars
        public GameObject portalTarget;
        public GameObject playerTarget;
        public PatrolPoint currentPatrolPoint;
        public WaterTarget currentWaterTarget;
        public float floatingHeight;
        public NavMeshAgent navMeshRef;
        public float safeDistance = 1f;
        
        void Start()
        {
            //Grab all the components needed for reference
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
                playerTarget = currentFOV.listOfTargets[1];
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
                antAIRef.worldState.BeginUpdate(antAIRef.planner);
                antAIRef.worldState.Set("PlayerFound", true);
                antAIRef.worldState.EndUpdate();
                antAIRef.SetGoal("ReturnToPortal");
            }
            else
            {
                antAIRef.worldState.BeginUpdate(antAIRef.planner);
                antAIRef.worldState.Set("PlayerFound", false);
                antAIRef.worldState.EndUpdate();
                antAIRef.SetGoal("PatrolLoop");
            }
        }
    }
}