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
         public JudasWitnessModel judasWitnessModel;
         public AntAIAgent antAIAgent;
         public float remainingDistance = 3f;
         
         public override void Create(GameObject aGameObject)
         {
             base.Create(aGameObject);
    
             owner = aGameObject;
             antAIAgent = owner.GetComponent<AntAIAgent>();
             judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
             remainingDistance = 3f;
         }
         
         public override void Enter()
         {
             base.Enter();
             
             Debug.Log("Move to resource state");

             if (judasWitnessModel.waterTargets.Count < 0)
             {
                 Debug.Log("waterTarget Null");
                 Finish();
             }
         }
         
         public override void Execute(float aDeltaTime, float aTimeScale)
         {
             base.Execute(aDeltaTime, aTimeScale);

             if (judasWitnessModel.waterTargets.Count > 0)
             {
                 if (judasWitnessModel.currentWaterTarget != null)
                 {
                     float betweenPosAndResource = 
                         Vector3.Distance(judasWitnessModel.transform.position, judasWitnessModel.currentWaterTarget.transform.position);
                     Debug.DrawLine( judasWitnessModel.transform.position, 
                         judasWitnessModel.currentWaterTarget.transform.position,Color.blue);
                 
                     if (betweenPosAndResource < remainingDistance)
                     {
                         Debug.Log("At resource position");
                                  
                         judasWitnessModel.waterTargets.Remove(judasWitnessModel.currentWaterTarget);
                                  
                         Finish();
                     }
                 }
             }

             if (judasWitnessModel.currentWaterTarget == null)
             {
                 Finish();
             }
             
         }

         public override void Exit()
         {
             base.Exit();
             
             antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
             antAIAgent.worldState.Set("atResourcePos", true);
             antAIAgent.worldState.EndUpdate();
         }
    }
}
