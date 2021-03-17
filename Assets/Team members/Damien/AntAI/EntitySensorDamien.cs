using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

public class EntitySensorDamien : MonoBehaviour, ISense
{
    public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
    {
        aWorldState.BeginUpdate(aAgent.planner);
        aWorldState.Set("At Target", false);
        aWorldState.Set("Has Target", false);
        aWorldState.EndUpdate();
    }
}
