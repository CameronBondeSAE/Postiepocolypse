using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class EntitySensor : MonoBehaviour, ISense
    {
        public GameObject owner;

        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            aWorldState.BeginUpdate(aAgent.planner);
            aWorldState.Set("Arrived at Target", false);
            aWorldState.Set("Target Chosen", false);
            aWorldState.Set("Target Blinded", false);
            aWorldState.Set("Energy Picked", false);
            aWorldState.Set("Arrived at Energy", false);
            aWorldState.Set("Light Energy is Full", false);
            aWorldState.Set("Target in View Range", false);
            aWorldState.Set("Patrolling", false);
            aWorldState.EndUpdate();
        }
    }
}
