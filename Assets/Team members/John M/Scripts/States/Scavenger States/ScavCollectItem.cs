using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Tanks;
using UnityEngine;
using UnityEngine.AI;

namespace JonathonMiles
{
    public class ScavCollectItem : AntAIState
    {
        private GameObject owner;
        private NavMeshAgent _navMeshAgent;
        //private GameObject itemTarget;
        
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            _navMeshAgent = owner.GetComponent<NavMeshAgent>();
            
        }

        public override void Enter()
        {
            base.Enter();
            if (owner.GetComponent<ScavengerMain>().itemTarget != null)
            {
                _navMeshAgent.SetDestination(owner.GetComponent<ScavengerMain>().itemTarget.transform.position);
            }
            //itemTarget = owner.GetComponent<ScavengerMain>().itemTarget;
            owner.GetComponent<ScavengerMain>().currentTarget = null;
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (_navMeshAgent.remainingDistance <= 1f)
            {
                if (owner.GetComponent<ScavengerMain>().itemTarget != null)
                {
                    owner.GetComponent<ScavengerMain>().itemTarget.GetComponent<PickUpItem>().PickUp(owner);
                    owner.GetComponent<Inventory>().Add(owner.GetComponent<ScavengerMain>().itemTarget.GetComponent<PickUpItem>().item);
                    
                }
                else
                {
                    Finish();
                }
                Finish();
                
            }
        }

        public override void Exit()
        {
            base.Exit();
            owner.GetComponent<ScavengerMain>().itemTarget = null;
            AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("See Item", false);
            antAIAgent.worldState.Set("Has Item", false);
            antAIAgent.worldState.EndUpdate();


        }
    }
}

