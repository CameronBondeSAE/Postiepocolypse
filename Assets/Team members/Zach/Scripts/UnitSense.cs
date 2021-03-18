using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;


namespace ZachFrench
{
    public class UnitSense : MonoBehaviour, ISense
    {
        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            aWorldState.BeginUpdate(aAgent.planner);
            aWorldState.Set("Has Target", aAgent.GetComponent<NavDudeBody>().target != null);
            aWorldState.Set("Is at Target", false );
            aWorldState.EndUpdate();
        }
    }
}
