using System.Threading;
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
                Thread thread = new Thread(NormalThreads);
                thread.Start();
            }
        }

        // Update is called once per frame
        /*private void DoStuff()
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
        }*/

        public float total = 0;

        private void NormalThreads()
        {
            float answer = 0;

            for (int i = 0; i < 10; i++)
            {
                answer += Mathf.Sqrt(i) + Mathf.PerlinNoise(i * 1.24f, 0);
            }

            total = total + answer;
        }
    }
}

