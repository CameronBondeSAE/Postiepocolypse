using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;
using ZachFrench;

namespace Luke
{
    public class MoveToResourceState : AntAIState
    {
         public GameObject owner;
         public NavMeshAgent navMeshAgent;
         public List<PatrolPoint> waterTargets;
         public PatrolManager patrolManager;
         public PatrolPoint currentWaterTarget;
         public float remainingDistance = .5f;
         
         public override void Create(GameObject aGameObject)
         {
             base.Create(aGameObject);
    
             owner = aGameObject;
             navMeshAgent = owner.GetComponent<NavMeshAgent>();
             patrolManager = FindObjectOfType<PatrolManager>();
             
             
             waterTargets = patrolManager.waterTargets;
         }
         
         public override void Enter()
         {
             base.Enter();
             
             Debug.Log("Move to resource state");
             currentWaterTarget = waterTargets[Random.Range(0, waterTargets.Count)];
             
             if (waterTargets != null)
             {
                 navMeshAgent.SetDestination(currentWaterTarget.transform.position);
             }
         }
         
         public override void Execute(float aDeltaTime, float aTimeScale)
         {
             base.Execute(aDeltaTime, aTimeScale);

             if (waterTargets == null)
             {
                 Debug.Log("waterTarget Null");
                 Finish();
             }
             
             if (navMeshAgent.remainingDistance < remainingDistance)
             {
                 Finish();
             }
         }

         public override void Exit()
         {
             base.Exit();

             waterTargets.Remove(currentWaterTarget);
             
             //setting the world condition
             AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
             antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
             antAIAgent.worldState.Set("atResourcePos", false);
             antAIAgent.worldState.EndUpdate();
             
             Debug.Log("At resource position");
         }
    }
}
