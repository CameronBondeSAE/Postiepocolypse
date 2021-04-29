using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace RileyMcGowan
{
    public class FindEnergy : AntAIPlannerState
    {
        //Public Vars
        
        //Private Vars

        public override void Enter()
        {
            base.Enter();
            //Store all possible targets of type WaterTarger in targetArray
            WaterTarget[] targetArray = FindObjectsOfType<WaterTarget>();
            //Set the target using a random target from the array and make it currentTarget
            WaterTarget currentTarget = targetArray[Random.Range(0, targetArray.Length)];
            //Tell the parent what the target is
            creatureMainRef.currentWaterTarget = currentTarget.gameObject;
            Finish();
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
        }
    }
}