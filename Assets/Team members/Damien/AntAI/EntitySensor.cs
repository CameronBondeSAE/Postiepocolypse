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
            aWorldState.Set("Close to Target", false);
            aWorldState.Set("Target Chosen", false);
            aWorldState.Set("Target Blinded", false);
            aWorldState.Set("Energy Location Found", false);
            aWorldState.Set("Arrived at Energy", false);
            aWorldState.Set("Energy is full", false);
            aWorldState.Set("Target is in view range", false);
            aWorldState.Set("Patrolling", false);
            aWorldState.EndUpdate();
        }
    }
}
