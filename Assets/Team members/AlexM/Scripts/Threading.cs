using System.Threading;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace AlexM
{
    public class Threading : MonoBehaviour
    {
        
        
        void Update()
        {
            if (InputSystem.GetDevice<Keyboard>().spaceKey.IsPressed())    
            {
                Thread myThread = new Thread(DoTheThing);
                myThread.Start();
            }

            if (InputSystem.GetDevice<Keyboard>().jKey.IsPressed())
            {
                ThreadingJobs job = new ThreadingJobs();
                job.Schedule();
            }
        }

        private void DoTheThing(object obj)
        {
            while (true)    
            {
                Thread.Sleep(1000);
                Debug.Log("A Wonderful day for a walk");
                Thread.Sleep(2500);
                Debug.Log("Whats that in the sky?...");
                Thread.Sleep(1500);
                Debug.Log("Oh Shi..");
                Thread.Sleep(2500);
                Debug.Log("I'm Dead.. X.X");
            }
        
        }
    }
}
