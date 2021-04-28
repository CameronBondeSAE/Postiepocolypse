using System.Collections.Generic;
using Anthill.AI;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace Luke
{
    public class FindResourceState : AntAIState
    {
        public GameObject owner;
        public JudasWitnessModel judasWitnessModel;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Find resource state");

            if (judasWitnessModel.waterTargets != null)
            {
                //setting the world condition
                AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("foundResource", judasWitnessModel.waterTargets != null);
                antAIAgent.worldState.EndUpdate();
                Debug.Log("Found resource");
            }

            else
            {
                Debug.Log("No more waterTargets");
                Finish();
            }
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Exit find resource state");

            Finish();
        }
    }
}