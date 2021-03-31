using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Damien
{
    public class MoveToTarget : AntAIState
    {
        public GameObject blinder;
        NavMeshAgent _navMeshAgent;
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            blinder = aGameObject;
            _navMeshAgent = blinder.GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            _navMeshAgent.SetDestination(blinder.GetComponent<Blinder>().target.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (_navMeshAgent.remainingDistance < 1f)
            {
                blinder.GetComponent<Blinder>().target = null;
                Finish();
            }
        }
    }
}
