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
            //Begin World State Conditions
            aWorldState.BeginUpdate(aAgent.planner);
            //States Default States
            aWorldState.Set("TargetFound", false);
            aWorldState.Set("EnergyFound", false);
            aWorldState.Set("PlayerReached", false);
            aWorldState.Set("EnergyCollected", false);
            aWorldState.Set("EnergyDeposited", false);
            aWorldState.Set("PatrolCompleted", false);
            //End the World State Definition
            aWorldState.EndUpdate();
        }
    }
}