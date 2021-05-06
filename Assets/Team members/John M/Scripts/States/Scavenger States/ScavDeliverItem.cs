using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;


namespace JonathonMiles
{
    public class ScavDeliverItem : AntAIState
    {
        private GameObject owner;
        private NavMeshAgent _navMeshAgent;
        
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            _navMeshAgent = owner.GetComponent<NavMeshAgent>();
            

        }
        public override void Enter()
        {
            base.Enter();
            _navMeshAgent.SetDestination(owner.GetComponent<ScavengerMain>().spawnPos.transform.position);
            Debug.Log(owner.GetComponent<ScavengerMain>().spawnPos.transform.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (_navMeshAgent.remainingDistance <= 5f)
            {
                owner.GetComponent<Inventory>().items.Clear();
                Finish();
            }
            
        }
        
        public override void Exit()
        {
            base.Exit();
            AntAIAgent _antAIAgent = owner.GetComponent<AntAIAgent>();
            _antAIAgent.worldState.BeginUpdate(_antAIAgent.planner);
            _antAIAgent.worldState.Set("Has Target", false);
            _antAIAgent.worldState.Set("Inventory Full", false);
            _antAIAgent.worldState.EndUpdate();
        }
    }
}

