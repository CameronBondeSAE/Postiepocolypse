using Anthill.AI;

using UnityEngine;

namespace JonathonMiles
{


    public class NavSensor : MonoBehaviour, ISense
    {
        
        

        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            
            aWorldState.BeginUpdate(aAgent.planner);
            aWorldState.Set("Found Item", false);
            aWorldState.Set("Move To Item", aAgent.GetComponent<NavMain>().itemTarget != null);
            aWorldState.Set("Collect Item", false);
            aWorldState.Set("See Player", false);
            aWorldState.Set("Retreat", false);
            aWorldState.Set("Deposit Item", false);
            aWorldState.Set("Move To Deposit", false);
            aWorldState.Set("Has Target", aAgent.GetComponent<NavMain>().currentTarget != null);
            aWorldState.Set("Arrived At Target", false);
            aWorldState.EndUpdate();
        }

        
    }
}

