using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class JudasWitnessSensor : MonoBehaviour, ISense
    {
        //remake this to read off the model 
        public JudasWitnessModel judasWitnessModel;

        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            judasWitnessModel = GetComponent<JudasWitnessModel>();
            
            aWorldState.BeginUpdate(aAgent.planner);
            {
                // This continuously checks overtime on update
                
                // aWorldState.Set(ExampleWorldScenario.gotResource, judasWitnessModel.gotResource);
                // aWorldState.Set(ExampleWorldScenario.playerFound, judasWitnessModel.playerIsNear);
                // aWorldState.Set(ExampleWorldScenario.needRecharge, judasWitnessModel.needRecharge);
                // aWorldState.Set(ExampleWorldScenario.foundResource, judasWitnessModel.foundResource);
                // aWorldState.Set(ExampleWorldScenario.deliveredResource, judasWitnessModel.deliveredResource);
                // aWorldState.Set(ExampleWorldScenario.atAttackRange, judasWitnessModel.atAttackRange);
                // aWorldState.Set(ExampleWorldScenario.atResourcePos, judasWitnessModel.atResourcePos);
                // aWorldState.Set(ExampleWorldScenario.foundRecharge, judasWitnessModel.foundRecharge);
                // aWorldState.Set(ExampleWorldScenario.atRechargePos,  judasWitnessModel.atRechargePos);
                // aAgent.worldState.Set("gotResource", false);
                // aAgent.worldState.Set("playerFound", false);
                // aAgent.worldState.Set("needRecharge", false);
                // aAgent.worldState.Set("foundResource", false);
                // aAgent.worldState.Set("deliveredResource", false);
                // aAgent.worldState.Set("atAttackRange", false);
                // aAgent.worldState.Set("atResourceRange", false);
                // aAgent.worldState.Set("foundRecharge", false);
                // aAgent.worldState.Set("atRechargePos", false);
            }
            aWorldState.EndUpdate();
        }
    }
}
