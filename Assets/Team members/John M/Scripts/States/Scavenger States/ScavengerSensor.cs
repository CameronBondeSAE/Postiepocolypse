using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace JonathonMiles
{
    public class ScavengerSensor : MonoBehaviour, ISense
    {
        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            aWorldState.BeginUpdate((aAgent.planner));
            
            //set state conditions in here
            aWorldState.Set("See Item", aAgent.GetComponent<ScavengerMain>().itemTarget != null);
            aWorldState.Set("Inventory Full", aAgent.GetComponent<ScavengerMain>().inventory.inventorySpace == aAgent.GetComponent<ScavengerMain>().inventory.items.Count);
            aWorldState.Set("Inventory Empty", false);
            //aWorldState.Set("Items Delivered", false);
            aWorldState.Set("Has Target", aAgent.GetComponent<ScavengerMain>().currentTarget != null);
            aWorldState.Set("Arrived At Target", false);
            
            aWorldState.EndUpdate();
        }
        
    }
}

