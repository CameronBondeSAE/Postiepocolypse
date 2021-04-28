using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace JonathonMiles
{
    public class MoveToTarget : AntAIState
    {
        public GameObject owner;
        public NavMeshAgent NavMeshAgent;


        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            NavMeshAgent = owner.GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            NavMeshAgent.SetDestination(owner.GetComponent<NavMain>().currentTarget.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (NavMeshAgent.remainingDistance < 1f)
            {
                owner.GetComponent<NavMain>().currentTarget = null;
                Finish();
            }
        }

        public override void Exit()
        {
            base.Exit();
            
        }
    } 
}

