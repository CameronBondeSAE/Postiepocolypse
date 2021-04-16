using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Damien
{
    public class MoveToTarget : AntAIState
    {
        public GameObject owner;
        NavMeshAgent _navMeshAgent;
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            _navMeshAgent = owner.GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            _navMeshAgent.SetDestination(owner.GetComponent<Blinder>().target.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (_navMeshAgent.remainingDistance < 1f)
            {
                owner.GetComponent<Blinder>().target = null;
                Finish();
            }
        }
    }
}
