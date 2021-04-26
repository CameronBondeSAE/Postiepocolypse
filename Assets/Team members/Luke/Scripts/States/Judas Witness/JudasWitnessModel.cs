using System.Collections.Generic;
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
        public AudioSource audioSource;
        public AudioChorusFilter chorusFilter;
        public float timeGathering;

        [Header("Patrol variables")] 
        public PatrolManager patrolManager;

        [Header("Audio")] 
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
            antAIAgent.worldState.Set("atResourceRange", false);
            antAIAgent.worldState.Set("foundRecharge", false);
            antAIAgent.worldState.Set("atRechargePos", false);
            antAIAgent.worldState.EndUpdate();

            
            patrolManager = FindObjectOfType<PatrolManager>();
            navMeshAgent = FindObjectOfType<NavMeshAgent>();

            InvokeRepeating("BasicNoises", timeBetweenAudio, audioRepeatRate);
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

        public void DirectionRaycast()
        {
            Debug.DrawRay(transform.position, transform.forward, Color.magenta);
        }

        public void Wander()
        {
            if (patrolManager == null)
            {
                patrolManager = FindObjectOfType<PatrolManager>();
            }
            if (patrolManager.pathsWithIndoors != null)
            {
                navMeshAgent.SetDestination(patrolManager.pathsWithIndoors[Random.Range(0, patrolManager.pathsWithIndoors.Count)].transform.position);
            }
        }
    }
}