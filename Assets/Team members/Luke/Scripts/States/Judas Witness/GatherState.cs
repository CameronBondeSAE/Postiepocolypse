using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Anthill.AI;

namespace Luke
{
    public class GatherState : AntAIState
    {
        public GameObject owner;
        public NavMeshAgent navMeshAgent;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
        
            owner = aGameObject;
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Gather state");
            
            StartCoroutine(GatheringResources());
        }
        
        public IEnumerator GatheringResources()
        {
            Debug.Log("Gathering Gathering");
            yield return new WaitForSeconds(owner.GetComponent<JudasWitnessModel>().timeGathering);
            
            //setting the world condition
            AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("gotResource", true);
            antAIAgent.worldState.EndUpdate();
            
            Finish();
        }
    }
}
