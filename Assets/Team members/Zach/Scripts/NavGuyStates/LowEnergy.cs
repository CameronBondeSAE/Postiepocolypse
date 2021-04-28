using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

public class LowEnergy : AntAIState
{
    public override void Create(GameObject aGameObject)
    {
        base.Create(aGameObject);
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("I have low energy");
    }

    public override void Execute(float aDeltaTime, float aTimeScale)
    {
        base.Execute(aDeltaTime, aTimeScale);
        Finish();
    }
}
