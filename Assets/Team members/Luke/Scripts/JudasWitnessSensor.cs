using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class JudasWitnessSensor : MonoBehaviour, ISense
    {
        public bool fakeGotResource = false;
        public bool fakePlayerIsNear = false;
        public bool fakeNeedRecharge = false;
        public bool fakeFoundResource = false;
        public bool fakeDeliveredResource = false;

        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            aWorldState.BeginUpdate(aAgent.planner);
            {
                aWorldState.Set(ExampleWorldScenario.gotResource, fakeGotResource);
                aWorldState.Set(ExampleWorldScenario.playerIsNear, fakePlayerIsNear);
                aWorldState.Set(ExampleWorldScenario.needRecharge, fakeNeedRecharge);
                aWorldState.Set(ExampleWorldScenario.foundResource, fakeFoundResource);
                aWorldState.Set(ExampleWorldScenario.deliveredResource, fakeDeliveredResource);
            }
            aWorldState.EndUpdate();
        }
    }
}
