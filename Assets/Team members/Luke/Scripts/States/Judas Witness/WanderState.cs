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

            judasWitnessModel.Wander();
        }

        public override void Exit()
        {
            base.Exit();
            
            Debug.Log("Exit Wander State");
        }
    }
}