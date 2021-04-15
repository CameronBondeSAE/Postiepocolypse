using Anthill.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CameronBonde
{
	public class Boter_Model : MonoBehaviour
	{
		public AntAIAgent antAIAgent;

		public WaterTarget target;
	
		// Start is called before the first frame update
		void Start()
		{
			// You can set a lot of the Planner in code as well as the graphical editor
			antAIAgent.SetGoal("Arrive at target");
		
			// antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
			// antAIAgent.worldState.Set("Am I at the target position", false);
			// antAIAgent.worldState.Set("Has target",                  false);
			// antAIAgent.worldState.EndUpdate();
		}
	}
}