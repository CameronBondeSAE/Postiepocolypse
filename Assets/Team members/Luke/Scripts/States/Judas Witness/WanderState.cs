using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using UnityEngine;
using UnityEngine.AI;

namespace Luke
{
    public class WanderState : AntAIState
    {
        public GameObject owner;
        public NavMeshAgent navMeshAgent;
        public JudasWitnessModel judasWitnessModel;
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
            
        }

        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("wander state");
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            
            judasWitnessModel.Patrol();
            
            Finish();
        }
    }
}
