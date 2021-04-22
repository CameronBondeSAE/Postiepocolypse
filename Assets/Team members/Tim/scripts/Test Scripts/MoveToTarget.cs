using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;
using ZachFrench;

namespace TimPearson
{
    public class MoveToTarget : AntAIState
    {
        public GameObject parent;
        private NavMeshAgent NavMeshAgent;
        public PatrolManager targets;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            parent = aGameObject;
            NavMeshAgent = parent.GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Moving");
            NavMeshAgent.SetDestination(parent.GetComponent<SprinterAI>().currentTarget.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (NavMeshAgent.remainingDistance < 1f)
            {
                parent.GetComponent<SprinterAI>().target = null;
                Finish();
            }
        }
    }
}

