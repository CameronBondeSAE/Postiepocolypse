using System.Collections.Generic;
using Anthill.AI;
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

            if (judasWitnessModel.waterTargets.Count >= 1)
            {
                //setting the world condition
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("foundResource", true);
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
                judasWitnessModel.SetWaterTarget();
                judasWitnessModel.waterTargets.Remove(judasWitnessModel.currentWaterTarget);
            }

            Debug.Log("Exit find resource state");
        }
    }
}