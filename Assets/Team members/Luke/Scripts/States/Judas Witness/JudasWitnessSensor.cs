using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class JudasWitnessSensor : MonoBehaviour, ISense
    {
        public bool fakeGotResource;
        public bool fakePlayerIsNear;
        public bool fakeNeedRecharge;
        public bool fakeFoundResource;
        public bool fakeDeliveredResource ;
        public bool fakeAtAttackRange;
        public bool fakeAtResourcePos;
        public bool fakeFoundRecharge;
        public bool fakeAtRechargePos;

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
