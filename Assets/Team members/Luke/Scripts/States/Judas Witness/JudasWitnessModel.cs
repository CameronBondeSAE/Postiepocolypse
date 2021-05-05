﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AlexM;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;
using ZachFrench;

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
        public List<PatrolPoint> waterTargets;
        public List<PatrolPoint> gatheredWaterTargets;
        public PatrolPoint currentWaterTarget;
        public Vector3 spawnPos;

        [Header("Attacking state variables")]
        public GameObject currentPlayerTarget;
        public int playerFoundIntensity;
        public float playerFoundGradient;

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
            ResetPlanner();

            patrolManager = FindObjectOfType<PatrolManager>();
            if (patrolManager == null)
            {
                return;
            }

            navMeshAgent = FindObjectOfType<NavMeshAgent>();

            InvokeRepeating("BasicNoises", timeBetweenAudio, audioRepeatRate);

            spawnPos = transform.position;
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

        //TODO not working yet because stuck between default and other states
        public IEnumerator WanderWaitTime()
        {
            yield return new WaitForSeconds(Random.Range(0, maxPatrolWaitTime));
        }

        public void SetWaterTarget()
        {
            if (waterTargets.Count > 0)
            {
                foreach (PatrolPoint target in waterTargets)
                {
                    if (target == gatheredWaterTargets.Contains(target))
                    {
                        waterTargets.Remove(target);
                    }
                }
            }
            else if(gatheredWaterTargets.Count <= 0)
            {
                waterTargets.AddRange(patrolManager.waterTargets);
            }
            
        }

        public void ResetPlanner()
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
            antAIAgent.worldState.EndUpdate();
        }
    }
}