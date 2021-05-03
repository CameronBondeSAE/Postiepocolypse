using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;
using ZachFrench;
using Random = UnityEngine.Random;

namespace Luke
{
    public class JudasWitnessModel : CreatureBase
    {
        [Header("Other considerations")] 
        public AntAIAgent antAIAgent;
        public NavMeshAgent navMeshAgent;
        public float timeGathering;

        [Header("Patrol variables")] 
        public PatrolManager patrolManager;
        public float patrolSpeed;
        public float maxPatrolWaitTime;
        
        [Header("Resource state variables")]
        public List<WaterTarget> waterTargets;
        public WaterTarget currentWaterTarget;
        public Vector3 spawnPos;

        [Header("Audio")] 
        public AudioSource audioSource;
        public AudioChorusFilter chorusFilter;
        public float timeBetweenAudio;
        public float audioRepeatRate;
        public float maxWetMix;
        public float maxRate;
        public float maxDepth;

        public void Start()
        {
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("gotResource", false);
            antAIAgent.worldState.Set("playerFound", false);
            antAIAgent.worldState.Set("needRecharge", false);
            antAIAgent.worldState.Set("foundResource", false);
            antAIAgent.worldState.Set("deliveredResource", false);
            antAIAgent.worldState.Set("atAttackRange", false);
            antAIAgent.worldState.Set("atResourcePos", false);
            antAIAgent.worldState.Set("foundRecharge", false);
            antAIAgent.worldState.Set("atRechargePos", false);
            antAIAgent.worldState.Set("wander", false);
            antAIAgent.worldState.EndUpdate();
            
            patrolManager = FindObjectOfType<PatrolManager>();
            if (patrolManager == null)
            {
                return;
            }
            navMeshAgent = FindObjectOfType<NavMeshAgent>();

            InvokeRepeating("BasicNoises", timeBetweenAudio, audioRepeatRate);
            
            spawnPos = transform.position;
            
            waterTargets.AddRange(FindObjectsOfType<WaterTarget>());
        }
        
        public void BasicNoises()
        {
            chorusFilter.wetMix1 = Mathf.PerlinNoise(Time.time / maxWetMix, 0);
            chorusFilter.rate = Mathf.PerlinNoise(Time.time / maxRate, 0);
            chorusFilter.depth = Mathf.PerlinNoise(Time.time / maxDepth, 0);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        public void Wander()
        {
            if (patrolManager == null)
            {
                patrolManager = FindObjectOfType<PatrolManager>();
                if (patrolManager == null)
                {
                    return;
                }
            }
            if (patrolManager.pathsWithIndoors != null)
            {
                navMeshAgent.speed = patrolSpeed;
            }
        }

        public IEnumerator WanderWaitTime()
        {
            yield return new WaitForSeconds(Random.Range(0, maxPatrolWaitTime));
        }

        public void SetWaterTarget()
        {
            if (waterTargets.Count != 0)
            {
                currentWaterTarget = waterTargets[Random.Range(0, waterTargets.Count)];
                navMeshAgent.SetDestination(currentWaterTarget.transform.position);
            }
        }
    }
}