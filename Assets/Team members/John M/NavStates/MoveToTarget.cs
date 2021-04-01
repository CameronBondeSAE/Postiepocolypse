using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace JonathonMiles
{
    public class MoveToTarget : AntAIState
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Start Move State");
        }
    } 
}


