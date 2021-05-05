using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace JonathonMiles
{
    
    public class SeePlayer : AntAIState
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
            Debug.Log("Entering See Player State");
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            
        }
    } 
}

