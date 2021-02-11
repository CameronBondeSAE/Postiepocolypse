using Anthill.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetState : AntAIState
{
	public override void Enter()
	{
		base.Enter();
		
		Debug.Log("Find target");
	}

	public override void Execute(float aDeltaTime, float aTimeScale)
	{
		base.Execute(aDeltaTime, aTimeScale);
		
		
	}

	public override void Exit()
	{
		base.Exit();
	}
}
