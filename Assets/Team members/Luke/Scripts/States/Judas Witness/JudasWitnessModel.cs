using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anthill.AI;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Luke
{

    public class JudasWitnessModel : MonoBehaviour
    {
        [Header("Other considerations")]
        public AntAIAgent antAIAgent;

        public NavMeshAgent navMeshAgent;
        public JudasTarget judasTarget;
        public AudioSource audioSource;
        public AudioChorusFilter chorusFilter;
        public float timeGathering;
        public float patrolSpeed;
        
        [Header("Patrol variables")]
        public Vector3 scale = Vector3.one;
        
        [HideInInspector]
        public Vector3 startPos;


        [Header("Audio")]
        public float timeBetweenAudio;
        public float audioRepeatRate;
        public float maxWetMix;
        public float maxRate;
        public float maxDepth;

        /// <summary>
        /// state bools
        /// </summary>
        [Header("State checks")]
        public bool gotResource;
        public bool playerIsNear;
        public bool needRecharge;
        public bool foundResource;
        public bool deliveredResource;
        public bool atAttackRange;
        public bool atResourcePos;
        public bool foundRecharge;
        public bool atRechargePos;
        
        

        void Start()
        {
            Debug.Log("Before states");
            
            startPos = transform.position;
            
            InvokeRepeating("BasicNoises",timeBetweenAudio,audioRepeatRate);
        }
        

        public void BasicNoises()
        {
            chorusFilter.wetMix1 = Mathf.PerlinNoise(Time.time/ maxWetMix, 0);
            chorusFilter.rate = Mathf.PerlinNoise(Time.time / maxRate, 0);
            chorusFilter.depth = Mathf.PerlinNoise(Time.time / maxDepth, 0);
            
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        public void DirectionRaycast()
        {
            Debug.DrawLine(transform.position, judasTarget.transform.position, Color.green);
        }

        public void Patrol()
        {
            navMeshAgent.speed = patrolSpeed;
            
            float x = Mathf.PerlinNoise(Time.time, startPos.x) * scale.x;
            float y = Mathf.PerlinNoise(Time.time, startPos.y) * scale.y;
            float z = Mathf.PerlinNoise(Time.time, startPos.z) * scale.z;
            
            transform.position = startPos + new Vector3(x, y, z);
        }
    }
}
