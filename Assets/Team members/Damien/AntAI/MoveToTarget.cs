using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Damien
{
    public class MoveToTarget : AntAIState
    {
        public GameObject owner;
        NavMeshAgent _navMeshAgent;
        private Blinder blinder;

        public AntAIAgent antAIAgent;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            _navMeshAgent = owner.GetComponent<NavMeshAgent>();
            blinder = GetComponent<Blinder>();
            antAIAgent = GetComponentInParent<AntAIAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            _navMeshAgent.SetDestination(owner.GetComponent<Blinder>().target.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);


            if (_navMeshAgent.remainingDistance < 4f)
            {
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("Close to Target", true);
                antAIAgent.worldState.EndUpdate();
                blinder.target = null;

                Finish();
            }
        }
    }
}