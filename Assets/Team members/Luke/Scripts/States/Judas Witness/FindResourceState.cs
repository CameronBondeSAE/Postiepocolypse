using System.Collections.Generic;
using System.Linq;
using AlexM;
using Anthill.AI;
using ParadoxNotion;
using UnityEngine;
using UnityEngine.AI;

namespace Luke
{
    public class FindResourceState : AntAIState
    {
        public GameObject owner;
        public JudasWitnessModel judasWitnessModel;
        public AntAIAgent antAIAgent;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            antAIAgent = owner.GetComponent<AntAIAgent>();
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Find resource state");
            //remove the players from this list
            judasWitnessModel.SetWaterTarget();
            judasWitnessModel.currentWaterTarget = judasWitnessModel.waterTargets[Random.Range(0, judasWitnessModel.waterTargets.Count)];
            
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            
            if (judasWitnessModel.waterTargets != null)
            {
                judasWitnessModel.waterTargets.Remove(judasWitnessModel.currentWaterTarget);
                
                //setting the world condition
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("foundResource", judasWitnessModel.currentWaterTarget != null);
                antAIAgent.worldState.EndUpdate();
                
                Debug.Log("Found resource");
                
                Finish();
            }

            else
            {
                Debug.Log("No more waterTargets");
                
                antAIAgent.SetDefaultState();
                
                Finish();
            }
        }

        public override void Exit()
        {
            base.Exit();
            
            if (judasWitnessModel.waterTargets != null)
            {
                if (judasWitnessModel.currentWaterTarget != null)
                {
                    judasWitnessModel.navMeshAgent.SetDestination( judasWitnessModel.currentWaterTarget.transform.position);
                }
            }

            Debug.Log("Exit find resource state");
        }
    }
}