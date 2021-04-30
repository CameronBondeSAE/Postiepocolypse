using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class PerlinSoundTweaker : MonoBehaviour
    {
        private AudioHighPassFilter hpFilter;
        private float cutoffFloat;
        
        void Start()
        {
            hpFilter = GetComponent<AudioHighPassFilter>();
        }
        
        void Update()
        {
            cutoffFloat = Mathf.PerlinNoise(Time.time, 0) * 1000f;
            if (cutoffFloat < 500)
            {
                cutoffFloat = 500;
                hpFilter.cutoffFrequency = cutoffFloat;
            }
            else
            {
                hpFilter.cutoffFrequency = cutoffFloat;
            }
            hpFilter.highpassResonanceQ = Random.Range(8,11);
        }
    }
}