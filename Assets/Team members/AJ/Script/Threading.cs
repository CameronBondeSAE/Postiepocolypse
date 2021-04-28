using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Mono.CecilX.Cil;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AJ
{
    public class Threading : MonoBehaviour
    {
        void Start()
        {
            for (int i = 0; i < 100; i++)
            {
                Job job = new Job();
                job.Schedule();
            }
        }

        // Start is called before the first frame update
        void Update()
        {
            
            if(InputSystem.GetDevice<Keyboard>().spaceKey.isPressed)
            {
                Thread thread = new Thread(DoStuff);
                thread.Start();
            }
        }

        // Update is called once per frame
        private void DoStuff()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Debug.Log("This is the first message");
                Thread.Sleep(2000);
                Debug.Log("This is the second message");
                Thread.Sleep(3000);
                Debug.Log("This is the third message");
                Thread.Sleep(4000);
                Debug.Log("This is the fourth message");
            }
        }
    }
}

