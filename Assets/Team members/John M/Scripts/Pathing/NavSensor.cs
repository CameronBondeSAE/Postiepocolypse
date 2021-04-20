using Anthill.AI;
using UnityEngine;
public class NavSensor : MonoBehaviour, ISense
{
    public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
    {
        
        aWorldState.BeginUpdate(aAgent.planner);
        aWorldState.Set("See MidPoint", aAgent.GetComponent<NavMain>().currentTarget !=null);
        aWorldState.EndUpdate();
    }
    
}
