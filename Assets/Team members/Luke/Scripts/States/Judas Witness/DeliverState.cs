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
        public WaterTarget[] waterTargets;
        public Vector3 returnResourcePos;
        public AntAIAgent antAIAgent;
        public JudasWitnessModel judasWitnessModel;
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
            returnResourcePos = transform.position;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Delivering");
            
            antAIAgent = owner.GetComponent<AntAIAgent>();
            navMeshAgent.SetDestination(returnResourcePos);
            waterTargets = FindObjectsOfType<WaterTarget>();

            // Here I need to find if there is any other water sources and if not wander
            if (waterTargets == null)
            {
                Finish();
            }

            navMeshAgent.SetDestination(judasWitnessModel.spawnPos);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            
            antAIAgent.worldState.Set("atResourcePos", false);
            
            owner.GetComponent<JudasWitnessModel>().DirectionRaycast();

            // Have we got to the target?
            if (navMeshAgent.remainingDistance < 1f)
            {
                //setting the world condition
                
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("deliveredResource", true);
                antAIAgent.worldState.EndUpdate();
                            
                Debug.Log("Delivered resource");
                
                Finish();
            }
        }

        public override void Exit()
        {
            base.Exit();
            
            //setting the world condition
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("foundResource", false);
            antAIAgent.worldState.Set("gotResource", false);
            antAIAgent.worldState.Set("deliveredResource", false);
            antAIAgent.worldState.EndUpdate();
        }
    }
}
