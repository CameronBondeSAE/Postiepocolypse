using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anthill.AI;

namespace Luke
{

    public class JudasWitnessModel : MonoBehaviour
    {
        public AntAIAgent antAIAgent;
        
        public FakeTarget target;

        void Start()
        {
            Debug.Log("Arrived at target");
        }
    }
}
