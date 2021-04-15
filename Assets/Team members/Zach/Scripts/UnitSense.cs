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
            aWorldState.Set("Has Target Patrol", aAgent.GetComponent<NavDudeBody>().target != null);
            aWorldState.Set("Is at Target Patrol", false );
            aWorldState.EndUpdate();
        }
    }
}
