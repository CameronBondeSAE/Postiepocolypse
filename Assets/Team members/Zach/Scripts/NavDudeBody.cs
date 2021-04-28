using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace ZachFrench
{

    public class NavDudeBody : MonoBehaviour
    {
        public PatrolPoint target;
        
        public AntAIAgent antAIAgent;

        public LayerMask playerLayer;

        private void Start()
        {
            antAIAgent.SetGoal("Patrol");
        }
    }
}
