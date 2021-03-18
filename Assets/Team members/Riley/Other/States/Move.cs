using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace RileyMcGowan
{
    public class Move : AntAIState
    {
        private float safeDistance;
        private NavMeshAgent parentNavMeshAgent;

        public GameObject owner;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
        }
        
        public override void Enter()
        {
            base.Enter();
            
            //Get the NavMeshAgent
            parentNavMeshAgent = owner.GetComponent<NavMeshAgent>();
            
            //Set the target
            parentNavMeshAgent.SetDestination(owner.GetComponent<Monster_Main>().currentTarget.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            //Take the safeDistance from the main script so all controls are on the main script
            safeDistance = owner.GetComponent<Monster_Main>().safeDistance;
            
            //Check the distance the monster has until it's finished
            if (parentNavMeshAgent.remainingDistance < safeDistance)
            {
                //Stop navigation and finish
                owner.GetComponent<Monster_Main>().currentTarget = null;
                Finish();
            }
        }
    }
}
