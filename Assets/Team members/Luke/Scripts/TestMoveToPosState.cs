using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine.AI;
using UnityEngine;

namespace Luke
{
    public class TestMoveToPosState : AntAIState
    {
        public GameObject owner;
        NavMeshAgent      navMeshAgent;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner        = aGameObject;
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("ENTER MOVE STATE");

            navMeshAgent.SetDestination(owner.GetComponent<TestAIModel>().target.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);

            // Have we got to the target?
            if (navMeshAgent.remainingDistance < 1f)
            {
                owner.GetComponent<TestAIModel>().target = null;
                Finish();
            }
        }
    }
}
