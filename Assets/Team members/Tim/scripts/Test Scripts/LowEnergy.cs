using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Tanks;
using UnityEngine;
using UnityEngine.AI;

namespace TimPearson
{
    public class LowEnergy : AntAIState
    {
        public GameObject parent;
        public SprintSense sprintSense;
        private NavMeshAgent NavMeshAgent;
        private Energy energy;
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            parent = aGameObject;
            sprintSense = parent.GetComponent<SprintSense>();
            NavMeshAgent = parent.GetComponent<NavMeshAgent>();
            energy = parent.GetComponent<Energy>();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Low Energy");
            NavMeshAgent.SetDestination(transform.position);
            //parent.transform.position = parent.transform.position;
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (energy.CurrentAmount > 10f)
            {
                Finish();
            }
        }
    }
}

