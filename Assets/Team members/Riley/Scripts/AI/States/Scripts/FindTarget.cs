using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace RileyMcGowan
{
    public class FindTarget : AntAIPlannerState
    {
        //Public Vars
        
        //Private Vars
        private bool isFinished;

        public override void Enter()
        {
            base.Enter();
            isFinished = false;
            //Store all possible targets of type Targer in targetArray
            PatrolPoint[] targetArray = FindObjectsOfType<PatrolPoint>();
            //Set the target using a random target from the array and make it currentTarget
            PatrolPoint currentTarget = targetArray[Random.Range(0, targetArray.Length)];
            //Tell the parent what the target is
            creatureMainRef.currentPatrolPoint = currentTarget;
            //Tell the find target to finish
            if (currentTarget != null)
            {
                isFinished = true;
            }
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (isFinished == true)
            {
                antAIRef.worldState.BeginUpdate(antAIRef.planner);
                antAIRef.worldState.Set("TargetFound", true);
                antAIRef.worldState.EndUpdate();
                Finish();
            }
        }
    }
}