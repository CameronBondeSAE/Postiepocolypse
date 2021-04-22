using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem;

public class Threading : MonoBehaviour
{
    private void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            CSharpJob job = new CSharpJob();
            JobHandle jobHandle = job.Schedule();
        }

        // for (int i = 0; i < 100; i++)
        // {
        //     Thread thread = new Thread(NormalThreads);
        //     thread.Start();
        // }
    }


    // Start is called before the first frame update
    void Update()
    {
        if (InputSystem.GetDevice<Keyboard>().spaceKey.isPressed)
        {
            Thread thread = new Thread(NormalThreads);
            thread.Start();
        }

        JobHandle jobHandle;
        if (InputSystem.GetDevice<Keyboard>().jKey.isPressed)
        {
            CSharpJob job = new CSharpJob();
            jobHandle = job.Schedule();
        }
    }

    // This is running in a thread
    private void NormalThreads()
    {
        float answer = 0;

        for (int i = 0; i < 10000000; i++)
        {
            answer+=Mathf.Sqrt(i)+Mathf.PerlinNoise(i*1.24f,0);
        }
    
        Debug.Log("I did something! : "+answer);
    }
}
