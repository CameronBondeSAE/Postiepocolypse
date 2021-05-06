using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Damien
{
    public class MoveToEnergy : AntAIState
    {
        public GameObject owner;
        NavMeshAgent _navMeshAgent;
        private Blinder blinder;
        public AntAIAgent antAIAgent;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            blinder = GetComponent<Blinder>();
            antAIAgent = GetComponentInParent<AntAIAgent>();
            _navMeshAgent = owner.GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            _navMeshAgent.SetDestination(owner.GetComponent<Blinder>().energyTarget.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);

            if (_navMeshAgent.remainingDistance < 5f)
            {
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("Arrived at Energy", true);
                antAIAgent.worldState.EndUpdate();
                //blinder.energyTarget = null;
                Finish();
            }
        }
    }
}