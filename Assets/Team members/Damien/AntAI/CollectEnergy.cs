using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class CollectEnergy : AntAIState
    {
        public GameObject owner;
        public AntAIAgent antAIAgent;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            antAIAgent = GetComponentInParent<AntAIAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("Light Energy is Full", true);
            antAIAgent.worldState.EndUpdate();
            Finish();
        }
    }
}