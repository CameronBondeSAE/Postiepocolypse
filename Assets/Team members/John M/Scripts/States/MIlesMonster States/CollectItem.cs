using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace JonathonMiles
{
    
    public class CollectItem : AntAIState
    {
        private GameObject owner;
        private NavMeshAgent _navMeshAgent;
        
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            _navMeshAgent = owner.GetComponent<NavMeshAgent>();

        }

        public override void Enter()
        {
            base.Enter();
            _navMeshAgent.SetDestination(owner.GetComponent<NavMain>().itemTarget.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (_navMeshAgent.remainingDistance <= 1f)
            {
                owner.GetComponent<NavMain>().itemTarget = null;
                Finish();
            }
        }
    } 
}

