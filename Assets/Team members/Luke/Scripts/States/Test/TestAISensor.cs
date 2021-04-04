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
            Debug.Log("Collecting conditions");
            
            aWorldState.BeginUpdate(aAgent.planner);
            aWorldState.Set("AtPosition", false);
            aWorldState.Set("HasTarget", aAgent.GetComponent<TestAIModel>().judasTarget != null);
            aWorldState.EndUpdate();
        }
    }
}
