using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class JobOutPut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NativeArray<int> result = new NativeArray<int>(1, Allocator.TempJob);
        SimpleJob simpleJob = new SimpleJob
        {
            a = 1,
            b = 2,
            result = result,
        };
        JobHandle jobHandle = simpleJob.Schedule();
        jobHandle.Complete();
        Debug.Log(simpleJob.result[0]);

        result.Dispose();
    }

    public struct SimpleJob : IJob
    {
        public int a;
        public int b;
        public NativeArray<int> result;

        public void Execute()
        {
            result[0] = a + b;
        }
    }
}
