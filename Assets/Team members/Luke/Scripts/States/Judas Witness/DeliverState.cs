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
        public Vector3 returnResourcePos;
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
            returnResourcePos = transform.position;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Delivering");
            
            navMeshAgent.SetDestination(returnResourcePos);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            
            owner.GetComponent<JudasWitnessModel>().DirectionRaycast();
            
            // Have we got to the target?
            if (navMeshAgent.remainingDistance < 1f)
            {
                //setting the world condition
                AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("deliveredResource", true);
                antAIAgent.worldState.EndUpdate();
                            
                Debug.Log("Delivered resource");
                
                Finish();
                
                // Here I need to find if there is any other water sources and if not wander
            }
        }
    }
}
