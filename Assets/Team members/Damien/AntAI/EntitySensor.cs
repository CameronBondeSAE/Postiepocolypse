using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class EntitySensor : MonoBehaviour, ISense
    {
        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            aWorldState.BeginUpdate(aAgent.planner);
            aWorldState.Set("At Target", false);
            aWorldState.Set("Has Target", false);
            aWorldState.EndUpdate();
        }
    }
}
