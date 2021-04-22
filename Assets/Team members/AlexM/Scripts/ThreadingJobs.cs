using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public struct ThreadingJobs : IJob
{
    private float ans;
    
    
    
    public void Execute()
    {
        for (int i = 0; i < 10000000; i++)
        {
            ans += Mathf.Sqrt(i) + Mathf.PerlinNoise(i * 1.24f, 0);
        }
        
        Debug.Log("Here: " + ans);
    }
}
