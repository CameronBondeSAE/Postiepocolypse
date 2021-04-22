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

        private void Start()
        {
            antAIAgent.SetGoal("Is at Position");
        }
    }
}
