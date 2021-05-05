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
        private WaterTarget currentTarget;
        
        public override void Enter()
        {
            base.Enter();
            creatureMainRef.swapColour = false;
            //Store all possible targets of type WaterTarger in targetArray
            WaterTarget[] targetArray = FindObjectsOfType<WaterTarget>();
            //Set the target using a random target from the array and make it currentTarget
            if (targetArray.Length > 0)
            {
                currentTarget = targetArray[Random.Range(0, targetArray.Length)];
                //Tell the parent what the target is
                creatureMainRef.currentWaterTarget = currentTarget.gameObject;
                Finish();
            }
            else
            {
                Debug.Log("No WaterTargets Exist " + owner);
                Finish();
            }
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
        }
    }
}