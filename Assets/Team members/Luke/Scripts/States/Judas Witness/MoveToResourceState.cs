using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Luke
{
    public class MoveToResourceState : AntAIState
    {
         public GameObject owner;
         public NavMeshAgent navMeshAgent;
         public FindResourceState findResourceState;
         public WaterTarget targetWater;
         public float remainingDistance = .5f;
         
         public override void Create(GameObject aGameObject)
         {
             base.Create(aGameObject);
    
             owner = aGameObject;
             navMeshAgent = owner.GetComponent<NavMeshAgent>();
         }
         
         public override void Enter()
         {
             base.Enter();
    
             Debug.Log("Move to resource state");

             targetWater = findResourceState.waterTarget[Random.Range(0,findResourceState.waterTarget.Length)];

             //setting the world condition
             AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
             antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
             antAIAgent.worldState.Set("gotResource", navMeshAgent.remainingDistance < remainingDistance);
             antAIAgent.worldState.EndUpdate();
         }
         
         public override void Execute(float aDeltaTime, float aTimeScale)
         {
             base.Execute(aDeltaTime, aTimeScale);

             if (findResourceState != null)
             {
                 navMeshAgent.SetDestination(targetWater.transform.position);
             }
             
             if (navMeshAgent.remainingDistance < remainingDistance)
             {
                 Finish();
             }
         }
    }
}
