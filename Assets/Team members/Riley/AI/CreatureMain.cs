using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Mirror;
using TimPearson;
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
        private Energy energyRef;

        //Public Vars
       [SyncVar] public GameObject portalTarget;
       [SyncVar] public GameObject playerTarget;
       [SyncVar] public GameObject currentPatrolPoint;
       [SyncVar] public GameObject currentWaterTarget;
        public float floatingHeight;
        public NavMeshAgent navMeshRef;
        public float safeDistance = 1f;
        public VisualEffect vfxComp;
        [SyncVar] public bool swapColour;
        [SyncVar] public bool energyCollecting;


        void Start()
        {
            energyCollecting = false;
            energyRef = GetComponent<Energy>();
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

                if (isServer)
                {
                    ResetPlanner();
                }
            }
        }

        [ClientRpc]
        public void RpcvfxDefault(Gradient gradient)
        {
            vfxComp.SetGradient("ActiveColour", gradient);
            colourHasSwapped = true;
        }

        [ClientRpc]
        public void RpcvfxAngry(Gradient gradient)
        {
            vfxComp.SetGradient("ActiveColour", gradient);
            colourHasSwapped = false;
        }

        [ClientRpc]
        public void RpcPos(Vector3 pos)
        {
            transform.position = pos;
        }

        private void FixedUpdate()
        {

            if (isServer)
            {
                vfxComp.SetFloat("ParticleSpawnRate", Random.Range(0.0f, 0.5f));
                //Raycast leveling
                if (swapColour != true && colourHasSwapped != true)
                {
                    Gradient defaultColour = vfxComp.GetGradient("DefaultColour");
                    RpcvfxDefault(defaultColour);
                }
                else if (swapColour != false && colourHasSwapped != false)
                {
                    Gradient angryColour = vfxComp.GetGradient("EnemySpottedColour");
                    RpcvfxAngry(angryColour);
                }


                if (childRaycastHandler.distanceToPlatformInfo > floatingHeight && childRaycastHandler != null)
                {

                    Vector3 pos = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
                   RpcPos(pos);

                }
                else
                {
                    if (childRaycastHandler.distanceToPlatformInfo != floatingHeight && childRaycastHandler != null)
                    {

                        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.01f,
                            transform.position.z);
                        RpcPos(pos);

                    }
                }
            }

            //Check the FOV for a player target
            if (currentFOV.listOfTargets.Count > 0)
            {
                playerTarget = currentFOV.listOfTargets[0];
            }

            //Check if the object should be moving
            if (playerTarget != null || currentWaterTarget != null || currentPatrolPoint != null ||
                portalTarget != null)
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

            if (energyCollecting != false)
            {
                energyRef.CurrentAmount += .2f;
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
            if (energyCollecting != true)
            {
                if (isServer)
                {
                    StartCoroutine(CollectEnergy());
                }
            }
        }

        IEnumerator CollectEnergy()
        {
            energyCollecting = true;
            antAIRef.worldState.BeginUpdate(antAIRef.planner);
            antAIRef.worldState.Set("PlayerReached", false);
            antAIRef.worldState.EndUpdate();
            Gradient energyColour = vfxComp.GetGradient("EnergyCollect");
            vfxComp.SetGradient("ActiveColour", energyColour);
            yield return new WaitForSeconds(4);
            currentWaterTarget = null;
            playerTarget = null;
            yield return new WaitForSeconds(1);
            antAIRef.worldState.BeginUpdate(antAIRef.planner);
            antAIRef.worldState.Set("EnergyCollected", true);
            antAIRef.worldState.EndUpdate();
            energyCollecting = false;
        }
    }
}