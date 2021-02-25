using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class JudasWitnessSensor : MonoBehaviour, ISense
    {
        public bool fakeCanConvert = false;
        public bool fakePlayerIsNear = false;
        public bool fakeNeedRecharge = false;
        public bool fakeFoundConvertTarget = false;

        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            aWorldState.BeginUpdate(aAgent.planner);
            {
                aWorldState.Set(ExampleWorldScenario.canConvert, fakeCanConvert);
                aWorldState.Set(ExampleWorldScenario.playerIsNear, fakePlayerIsNear);
                aWorldState.Set(ExampleWorldScenario.needRecharge, fakeNeedRecharge);
                aWorldState.Set(ExampleWorldScenario.foundConvertTarget, fakeFoundConvertTarget);
            }
            aWorldState.EndUpdate();
        }
    }
}
