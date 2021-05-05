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
            aWorldState.Set("Target Chosen", GetComponent<Blinder>().target != null);
            aWorldState.Set("Energy Picked", GetComponent<Blinder>().energyTarget != null);
            aWorldState.EndUpdate();
        }

       
    }
}
