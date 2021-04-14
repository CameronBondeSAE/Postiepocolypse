using Anthill.AI;
using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using UnityEngine;

public class Monster_Sensor : MonoBehaviour, ISense
{
    public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
    {
        //aWorldState refers to the WorldState in the planner
        //aAgent
        aWorldState.BeginUpdate(aAgent.planner);
        //Set our current location to not there
        aWorldState.Set("Am I here", false);
        //Check if we have a target andd if not false it
        aWorldState.Set("Target Picked", aAgent.GetComponent<Monster_Main>().currentTarget != null);
        //End our meddling
        aWorldState.EndUpdate();
    }
}
