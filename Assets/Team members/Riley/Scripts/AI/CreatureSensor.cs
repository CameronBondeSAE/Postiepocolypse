using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace RileyMcGowan
{
    public class CreatureSensor : MonoBehaviour, ISense
    {
        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            //Reference Default World State
            aWorldState.BeginUpdate(aAgent.planner);
            //States Default States
            aWorldState.Set("TestName", false);
            //End the world state
            aWorldState.EndUpdate();
        }
    }
}