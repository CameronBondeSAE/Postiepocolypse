using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Mono.CecilX.Cil;
using UnityEngine;

namespace AJ
{
    public class Threading : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Thread thread = new Thread(DoStuff);
            thread.Start();
            
            

        }

        // Update is called once per frame
        private void DoStuff()
        {
            Thread.Sleep(3000);
            Debug.Log("This is the first message");
            Thread.Sleep(6000);
            Debug.Log("This is the second message");
            //TimeSpan interval = TimeSpan.FromDays(49);
            //TimeSpan interval = TimeSpan.FromDays(double.NegativeInfinity);
            Thread.Sleep(9000);
            Debug.Log("This is the third message");
            Thread.Sleep(12000);
            Debug.Log("This is the fourth message");
        }
    }
}

