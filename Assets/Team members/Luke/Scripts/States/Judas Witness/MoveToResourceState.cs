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
             findResourceState = owner.GetComponentInChildren<FindResourceState>();
         }
         
         public override void Enter()
         {
             base.Enter();
    
             Debug.Log("Move to resource state");

         }
         
         public override void Execute(float aDeltaTime, float aTimeScale)
         {
             base.Execute(aDeltaTime, aTimeScale);

             if (targetWater != null)
             {
                 navMeshAgent.SetDestination(findResourceState.waterTarget[Random.Range(0,findResourceState.waterTarget.Length)].transform.position);
             }

             if (navMeshAgent.remainingDistance < remainingDistance)
             {
                 //setting the world condition
                 AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
                 antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                 antAIAgent.worldState.Set("atResourcePos", navMeshAgent.remainingDistance < remainingDistance);
                 antAIAgent.worldState.EndUpdate();
             
                 Debug.Log("At resource position");
                 Finish();
             }
             
             else if (targetWater == null)
             {
                 Debug.Log("waterTarget Null");
                 Finish();
             }
         }
    }
}
