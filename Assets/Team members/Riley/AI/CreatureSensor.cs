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
            CreatureMain cr = aAgent.GetComponent<CreatureMain>();
            //States Default States
            aWorldState.Set("TargetFound", cr.currentPatrolPoint != null);
            aWorldState.Set("EnergyFound", cr.currentWaterTarget != null);
            aWorldState.Set("PlayerFound", cr.playerTarget != null);
            //End the World State Definition
            aWorldState.EndUpdate();
        }
    }
}