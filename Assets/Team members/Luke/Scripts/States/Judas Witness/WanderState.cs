using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
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

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
        }

        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("wander state");
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            
            judasWitnessModel.Wander();
        }

        public override void Exit()
        {
            base.Exit();
            
            Debug.Log("Exit Wander State");
        }
    }
}
