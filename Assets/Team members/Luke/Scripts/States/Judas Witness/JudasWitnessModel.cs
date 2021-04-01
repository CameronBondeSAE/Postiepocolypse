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
        public AntAIAgent antAIAgent;
        public Target target;
        public AudioSource audioSource;
        public AudioChorusFilter chorusFilter;
        public float timeBetweenAudio;
        public float audioRepeatRate;

        public float maxWetMix;
        public float maxRate;
        public float maxDepth;

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
    }
}
