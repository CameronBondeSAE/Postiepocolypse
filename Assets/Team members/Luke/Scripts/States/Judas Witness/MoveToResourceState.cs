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
         public WaterTarget[] waterTarget;
         public float remainingDistance = .5f;
         
         public override void Create(GameObject aGameObject)
         {
             base.Create(aGameObject);
    
             owner = aGameObject;
             navMeshAgent = owner.GetComponent<NavMeshAgent>();
             waterTarget = FindObjectsOfType<WaterTarget>();
         }
         
         public override void Enter()
         {
             base.Enter();
    
             Debug.Log("Move to resource state");
             
             if (waterTarget != null)
             {
                 navMeshAgent.SetDestination(waterTarget[Random.Range(0, waterTarget.Length)].transform.position);
             }
         }
         
         public override void Execute(float aDeltaTime, float aTimeScale)
         {
             base.Execute(aDeltaTime, aTimeScale);

             if (navMeshAgent.remainingDistance < remainingDistance)
             {
                 //setting the world condition
                 AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
                 antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                 antAIAgent.worldState.Set("atResourcePos", true);
                 antAIAgent.worldState.EndUpdate();
             
                 Debug.Log("At resource position");
                 Finish();
             }
             
             else if (waterTarget == null)
             {
                 Debug.Log("waterTarget Null");
                 Finish();
             }
         }
    }
}
