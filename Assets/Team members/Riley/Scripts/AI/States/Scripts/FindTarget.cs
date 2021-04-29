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
        private PatrolPoint[] targetArray;
        private PatrolPoint currentTarget;

        public override void Enter()
        {
            base.Enter();
            isFinished = false;
            //Store all possible targets of type Targer in targetArray
            targetArray = FindObjectsOfType<PatrolPoint>();
            //Set the target using a random target from the array and make it currentTarget
            currentTarget = targetArray[Random.Range(0, targetArray.Length)];
            
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