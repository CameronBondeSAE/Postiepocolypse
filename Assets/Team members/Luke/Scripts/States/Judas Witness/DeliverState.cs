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
            antAIAgent = owner.GetComponent<AntAIAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Delivering");

            navMeshAgent.SetDestination(judasWitnessModel.spawnPos);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);

            float distanceBetweenPosAndSpawn = 
                Vector3.Distance(judasWitnessModel.transform.position, judasWitnessModel.spawnPos);

            // Have we got to the target position?
            if (distanceBetweenPosAndSpawn < 3f)
            {
                StartCoroutine(DeliveredWaitTime());
            }
        }

        public IEnumerator DeliveredWaitTime()
        {
            yield return new WaitForSeconds(4f);

            //setting the world condition
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("deliveredResource", true);
            antAIAgent.worldState.EndUpdate();
                            
            Debug.Log("Delivered resource");
            Finish();
        }

        public override void Exit()
        {
            base.Exit();
            
            judasWitnessModel.currentWaterTarget = null;
            judasWitnessModel.ResetPlanner();
        }
    }
}
