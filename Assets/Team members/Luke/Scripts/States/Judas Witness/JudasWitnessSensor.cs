using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class JudasWitnessSensor : MonoBehaviour, ISense
    {
        public JudasWitnessModel judasWitnessModel;

        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            judasWitnessModel = GetComponent<JudasWitnessModel>();
            
            aWorldState.BeginUpdate(aAgent.planner);
            {
                
            }
            aWorldState.EndUpdate();
        }
    }
}
