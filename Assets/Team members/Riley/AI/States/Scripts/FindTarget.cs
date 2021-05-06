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
        private PatrolPoint[] targetArray;
        private PatrolPoint currentTarget;

        public override void Enter()
        {
            base.Enter();
            antAIRef.worldState.BeginUpdate(antAIRef.planner);
            antAIRef.worldState.Set("PatrolCompleted", false);
            antAIRef.worldState.EndUpdate();
            creatureMainRef.currentPatrolPoint = null;
            //Store all possible targets of type Targer in targetArray
            targetArray = FindObjectsOfType<PatrolPoint>();
            //Set the target using a random target from the array and make it currentTarget
            if (targetArray.Length > 0)
            {
                currentTarget = targetArray[Random.Range(0, targetArray.Length)];
            }
            else
            {
                Debug.Log("No PatrolPoints Exist " + owner);
            }
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (currentTarget is WaterTarget)
            {
                currentTarget = targetArray[Random.Range(0, targetArray.Length)];
            }
            else
            {
                //Tell the parent what the target is
                creatureMainRef.currentPatrolPoint = currentTarget.gameObject;
                Finish();
            }
        }
    }
}