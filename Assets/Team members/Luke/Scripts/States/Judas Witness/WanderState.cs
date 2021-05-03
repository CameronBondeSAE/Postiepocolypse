using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;
using ZachFrench;

namespace Luke
{
    public class WanderState : AntAIState
    {
        public GameObject owner;
        public JudasWitnessModel judasWitnessModel;
        public NavMeshAgent navMeshAgent;
        public PatrolManager patrolManager;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
            patrolManager = FindObjectOfType<PatrolManager>();
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("wander state");

            AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("wander", true);
            antAIAgent.worldState.EndUpdate();

            judasWitnessModel.Wander();
        }

        public override void Exit()
        {
            base.Exit();
            
            AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("wander", false);
            antAIAgent.worldState.EndUpdate();
            
            Debug.Log("Exit Wander State");
        }
    }
}