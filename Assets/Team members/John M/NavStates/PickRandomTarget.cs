using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace JonathonMiles
{
    public class PickRandomTarget : AntAIState
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Pick Target State");
        }
    }
}

