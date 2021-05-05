using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace JonathonMiles
{
    
    public class Retreat : AntAIState
    {
        private GameObject owner;
        private NavMeshAgent _navMeshAgent;
        private Transform playerPosition;
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            _navMeshAgent = owner.GetComponent<NavMeshAgent>();
            playerPosition = owner.GetComponent<NavMain>().playerTarget;

        }

        public override void Enter()
        {
            base.Enter();
            //do something to player position here
            
            //set the destination to be the new position here
            
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            //check that the AI has reached that new destination here
            
            //apply nulls
            //owner.GetComponent<NavMain>().playerTarget = null;
            
            //Finish();
        }
    } 
}

