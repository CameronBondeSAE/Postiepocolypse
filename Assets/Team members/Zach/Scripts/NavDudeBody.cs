using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace ZachFrench
{

    public class NavDudeBody : CreatureBase
    {
        public PatrolPoint target;
        
        public AntAIAgent antAIAgent;

        private void Start()
        {
            antAIAgent.SetGoal("Patrol");
        }
    }
}
