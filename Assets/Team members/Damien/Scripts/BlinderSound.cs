using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinderSound : MonoBehaviour
{
    public AudioHighPassFilter laughing;
    
    public 
    // Update is called once per frame
    void Update()
    {
        laughing.cutoffFrequency = Mathf.PerlinNoise(Time.time / 2f, 0) * 3000f + 5000;
    }
}
