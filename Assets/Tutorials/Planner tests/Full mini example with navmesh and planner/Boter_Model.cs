using Anthill.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boter_Model : MonoBehaviour
{
	public AntAIAgent antAIAgent;

	public FakeTarget target;
	
    // Start is called before the first frame update
    void Start()
    {
        antAIAgent.SetGoal("Arrive at target");
		
		// antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
		// antAIAgent.worldState.Set("Am I at the target position", false);
		// antAIAgent.worldState.Set("Has target",                  false);
		// antAIAgent.worldState.EndUpdate();
    }
}
