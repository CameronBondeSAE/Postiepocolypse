using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace TimPearson
{
    public class SprintSense : MonoBehaviour, ISense
    {
        public Energy energy;
        public bool lowEnergy;
        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            CheckForEnergy();
            aWorldState.BeginUpdate(aAgent.planner);
            aWorldState.Set("Has Target", aAgent.GetComponent<SprinterAI>().currentTarget != null);
            aWorldState.Set("At Target", false);
            aWorldState.Set("Low Energy", lowEnergy);
            aWorldState.EndUpdate();
        }
        public void CheckForEnergy()
        {
            if (energy.CurrentAmount <= 1f)
            {
                lowEnergy = true;
            }
            else if (energy.CurrentAmount>1f)
            {
                lowEnergy = false;
            }
        }
    }

}
