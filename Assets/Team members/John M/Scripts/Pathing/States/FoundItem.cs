
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace JonathonMiles
{
    public class FoundItem : AntAIState
    {
        public GameObject owner;
        private NavMeshAgent NavMeshAgent;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
        }

        public override void Enter()
        {
            base.Enter();
            NavMeshAgent = owner.GetComponent<NavMeshAgent>();
            
            Finish();
        }
    }
}

