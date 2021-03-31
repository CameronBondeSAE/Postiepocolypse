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
        public bool fakeAtAttackRange = false;
        public bool fakeAtResourcePos = false;
        public bool fakeFoundRecharge = false;
        public bool fakeAtRechargePos = false;

        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            aWorldState.BeginUpdate(aAgent.planner);
            {
                aWorldState.Set(ExampleWorldScenario.gotResource, fakeGotResource);
                aWorldState.Set(ExampleWorldScenario.playerFound, fakePlayerIsNear);
                aWorldState.Set(ExampleWorldScenario.needRecharge, fakeNeedRecharge);
                aWorldState.Set(ExampleWorldScenario.foundResource, fakeFoundResource);
                aWorldState.Set(ExampleWorldScenario.deliveredResource, fakeDeliveredResource);
                aWorldState.Set(ExampleWorldScenario.atAttackRange, fakeAtAttackRange);
                aWorldState.Set(ExampleWorldScenario.atResourcePos, fakeAtResourcePos);
                aWorldState.Set(ExampleWorldScenario.foundRecharge, fakeFoundRecharge);
                aWorldState.Set(ExampleWorldScenario.atRechargePos, fakeAtRechargePos);
            }
            aWorldState.EndUpdate();
        }
    }
}
