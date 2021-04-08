using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anthill.AI;
using Random = UnityEngine.Random;

namespace Luke
{

    public class JudasWitnessModel : MonoBehaviour
    {
        [Header("Other considerations")]
        public AntAIAgent antAIAgent;
        public JudasTarget judasTarget;
        public AudioSource audioSource;
        public AudioChorusFilter chorusFilter;
        public float timeGathering;
        private Vector3 targetDirection;
        

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
            targetDirection = judasTarget.transform.position - transform.position;
            
            Debug.DrawLine(transform.position, judasTarget.transform.position, Color.green);
        }
    }
}
