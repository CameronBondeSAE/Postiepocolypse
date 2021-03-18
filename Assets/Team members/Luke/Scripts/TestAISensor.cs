using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class TestAISensor : MonoBehaviour, ISense
    {
        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            aWorldState.BeginUpdate(aAgent.planner);
            aWorldState.Set("At Position", false);
            aWorldState.Set("Has target", aAgent.GetComponent<TestAIModel>().target != null);
            aWorldState.EndUpdate();
        }
    }
}
