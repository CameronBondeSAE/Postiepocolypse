using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class Convert : AntAIState
    {
        public enum ExampleWorldScenario
        {
            canConvert = 0,
            playerIsNear = 1,
            needRecharge = 2,
            foundConvertTarget = 3
        }
        public override void Enter()
        {
            Debug.Log("Making Fog");
        }
    }
}
