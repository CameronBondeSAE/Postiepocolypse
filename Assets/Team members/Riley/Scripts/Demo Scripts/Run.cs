using Anthill.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : AntAIState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Run Away!");
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
