﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Anthill.AI;
using ZachFrench;

namespace Luke
{
    public class GatherState : AntAIState
    {
        public GameObject owner;
        public JudasWitnessModel judasWitnessModel;
        public NavMeshAgent navMeshAgent;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
        
            owner = aGameObject;
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Gather state");
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);

            if (navMeshAgent.remainingDistance < 3f)
            {
                StartCoroutine(GatheringResources());
            }   
        }

        public IEnumerator GatheringResources()
        {
            Debug.Log("Gathering wait time");
            yield return new WaitForSeconds(judasWitnessModel.timeGathering);
            judasWitnessModel.currentWaterTarget = null;

            Finish();
        }

        public override void Exit()
        {
            base.Exit();

            judasWitnessModel.currentWaterTarget = null;
            
            //setting the world condition
            AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("atResourcePos", false);
            antAIAgent.worldState.Set("gotResource", true);
            antAIAgent.worldState.EndUpdate();
        }
    }
}
