using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using UnityEngine;
using UnityEngine.AI;

namespace Luke
{
    public class MoveToPlayerState : AntAIState
    {
        public GameObject owner;
        public NavMeshAgent navMeshAgent;
        public JudasWitnessModel judasWitnessModel;
        public AntAIAgent antAIAgent;
        public FOV fov;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
            antAIAgent = owner.GetComponent<AntAIAgent>();
            fov = owner.GetComponent<FOV>();
        }

        public override void Enter()
        {
            base.Enter();

            if (judasWitnessModel.currentPlayerTarget != null)
            {
                navMeshAgent.SetDestination(judasWitnessModel.currentPlayerTarget.transform.position);
            }
            
            Debug.Log("Moving to player");
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);

            if (judasWitnessModel.currentPlayerTarget != null && navMeshAgent.remainingDistance < .5f)
            {
                //set vfx colour to red
                
                //setting the world condition
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("atAttackRange", true);
                antAIAgent.worldState.EndUpdate();
                Finish();
            }
            
            else if (judasWitnessModel.currentPlayerTarget == null)
            {
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("playerFound", false);
                antAIAgent.worldState.EndUpdate();
                Finish();
            }
            
            if (fov.listOfTargets.Count <= 0)
            {
                judasWitnessModel.currentPlayerTarget = null;
                //setting the world condition
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("atAttackRange", false);
                antAIAgent.worldState.EndUpdate();
            }
        }
    }
}
