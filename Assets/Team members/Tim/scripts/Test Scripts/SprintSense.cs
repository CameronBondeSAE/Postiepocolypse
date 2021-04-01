using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace TimPearson
{
    public class SprintSense : MonoBehaviour, ISense
    {
        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            aWorldState.BeginUpdate(aAgent.planner);
            aWorldState.Set("Has Target", aAgent.GetComponent<SprinterAI>().target != null);
            aWorldState.Set("At Target", false);
            aWorldState.EndUpdate();
        }
    }

}
