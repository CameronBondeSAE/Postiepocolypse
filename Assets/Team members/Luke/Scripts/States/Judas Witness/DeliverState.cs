using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Luke
{
    public class DeliverState : AntAIState
    {
        public GameObject owner;
        public NavMeshAgent navMeshAgent;
        private Vector3 targetDirection;
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Delivering");
            
            navMeshAgent.SetDestination(owner.GetComponent<JudasWitnessModel>().judasTarget.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            
            owner.GetComponent<JudasWitnessModel>().DirectionRaycast();
            
            // Have we got to the target?
            if (navMeshAgent.remainingDistance < 1f)
            {
                Finish();
            }
        }
    }
}
