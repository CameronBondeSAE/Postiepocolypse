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
        private SprinterAI sprinterai;
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
            //NavMeshAgent.SetDestination(transform.position);
            NavMeshAgent.isStopped = true;
            //parent.transform.position = parent.transform.position;
            sprinterai = parent.GetComponent<SprinterAI>();
            sprinterai.rayOn = false;
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (energy.CurrentAmount > energy.MaxAmount-1f)
            {
                NavMeshAgent.isStopped = false;
                sprinterai.rayOn = true;
                AntAIAgent antAIAgent = parent.GetComponent<AntAIAgent>();
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("Low Energy", false);
                antAIAgent.worldState.EndUpdate();
                Finish();
            }
        }
    }
}

