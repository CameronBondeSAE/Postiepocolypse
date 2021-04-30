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
        public Energy energy;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            parent = aGameObject;
            NavMeshAgent = parent.GetComponent<NavMeshAgent>();
            energy = parent.GetComponent<Energy>();
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
            if (NavMeshAgent.isStopped == true)
            {
                if (energy.CurrentAmount >= 10f)
                {
                    NavMeshAgent.isStopped = false;
                }
                
            }
            if (NavMeshAgent.remainingDistance < 1f)
            {
                parent.GetComponent<SprinterAI>().currentTarget = null;
                Finish();
            }
           
        }
    }
}

