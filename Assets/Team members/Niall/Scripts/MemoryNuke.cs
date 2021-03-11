using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

namespace Niall
{
    public class MemoryNuke : MonoBehaviour
    {
        private int power = 100;
        private GameObject go;
        private int t;
        void Update()
        {
            for (int i = 0; i < power; i++)
            {
                t++;
                new GameObject();
                Debug.Log("ITEM" + t);

            }
            
            Collect();
            
        }

        void Collect()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                GC.Collect();
                Debug.Log("GC.Collect initiated.");
            }
        }
    }
}