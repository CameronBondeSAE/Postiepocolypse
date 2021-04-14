using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light light;

    public bool flashOn;
    float startTime = 0;
    private float waitForSeconds = .5f;

    private void Start()
    {
    }

    private void Update()
    {
        if (flashOn)
        {
            light.intensity = 200000000f;
            
        }

        else
        {
            light.intensity = 0f;
        }
        
        //if (Input.anyKey)
        {
            for (int i = 0; i < 6; i++)
            {
                flashOn = true;
                if (flashOn && Time.time - startTime > waitForSeconds)
                {
                    flashOn = false;
                }
            }
        }
    }
}