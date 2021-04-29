using System.Collections;
using System.Collections.Generic;
using AlexM;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Luke
{
    public class DeliverState : AntAIState
    {
        public GameObject owner;
        public NavMeshAgent navMeshAgent;
        public AntAIAgent antAIAgent;
        public JudasWitnessModel judasWitnessModel;
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Delivering");

            navMeshAgent.SetDestination(judasWitnessModel.spawnPos);
            
            //setting the world condition
            antAIAgent = owner.GetComponent<AntAIAgent>();
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("atResourcePos", false);
            antAIAgent.worldState.EndUpdate();
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);

            // Have we got to the target position?
            if (navMeshAgent.remainingDistance < .5f)
            {
                //setting the world condition
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("deliveredResource", true);
                antAIAgent.worldState.EndUpdate();
                            
                Debug.Log("Delivered resource");

                DeliveredWiatTime();
                
                Finish();
            }
        }

        public IEnumerator DeliveredWiatTime()
        {
            yield return new WaitForSeconds(4f);
        }

        public override void Exit()
        {
            base.Exit();
            
            //setting the world condition
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("gotResource", false);
            antAIAgent.worldState.Set("playerFound", false);
            antAIAgent.worldState.Set("needRecharge", false);
            antAIAgent.worldState.Set("foundResource", false);
            antAIAgent.worldState.Set("deliveredResource", false);
            antAIAgent.worldState.Set("atAttackRange", false);
            antAIAgent.worldState.Set("atResourcePos", false);
            antAIAgent.worldState.Set("foundRecharge", false);
            antAIAgent.worldState.Set("atRechargePos", false);
            antAIAgent.worldState.EndUpdate();
        }
    }
}
