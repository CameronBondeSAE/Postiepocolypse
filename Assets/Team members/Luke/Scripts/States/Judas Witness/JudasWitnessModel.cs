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
        
        public Target target;

        void Start()
        {
            Debug.Log("Arrived at target");
        }
    }
}
