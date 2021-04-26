using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Luke
{
    public class FindResourceState : AntAIState
    {
        public GameObject owner;
        public WaterTarget[] waterTarget;
        public NavMeshAgent navMeshAgent;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Find resource state");
            waterTarget = FindObjectsOfType<WaterTarget>();
            
            //setting the world condition
            AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("foundResource", waterTarget != null);
            antAIAgent.worldState.EndUpdate();
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Exit find resource state");
            
            Finish();
        }
    }
}