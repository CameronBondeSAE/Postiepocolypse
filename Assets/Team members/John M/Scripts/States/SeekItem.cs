using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace JonathonMiles
{
    
    public class SeekItem : AntAIState
    {
        private GameObject owner;
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;

        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Moving towards item");
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
        }
    } 
}

