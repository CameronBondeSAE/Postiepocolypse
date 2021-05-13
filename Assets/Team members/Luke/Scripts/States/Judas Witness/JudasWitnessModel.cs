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
        public int normalIntensity;
        public float normalGradient;
        public int playerFoundIntensity;
        public float playerFoundGradient;
        public int attackingIntensity;
        public float attackingGradient;
        public float speedIncrease;

        [Header("Gather state variables")] 
        public float waterReduction; 
        public float timeGathering;
        
        [Header("Audio")] 
        public AudioSource audioSource;
        public AudioChorusFilter chorusFilter;
        public float timeBetweenAudio;
        public float audioRepeatRate;
        public float maxWetMix;
        public float maxRate;
        public float maxDepth;

        private NetworkJudas _networkJudas;
        
        public void Start()
        {
            _networkJudas = GetComponent<NetworkJudas>();
            
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
            if (isServer)
            {
                _networkJudas.BasicNoises();
            }
        }

        public void Wander()
        {
            if (isServer)
            {
                _networkJudas.Wander();
            }
        }

        //TODO not working yet because stuck between default and other states
        public IEnumerator WanderWaitTime()
        {
            yield return new WaitForSeconds(Random.Range(0, maxPatrolWaitTime));
        }

        public void SetWaterTarget()
        {
            if (isServer)
            {
                _networkJudas.SetWaterTarget();
            }
        }

        public void ResetPlanner()
        {
            if (isServer)
            {
                _networkJudas.ResetPlanner();
            }
        }
    }
}