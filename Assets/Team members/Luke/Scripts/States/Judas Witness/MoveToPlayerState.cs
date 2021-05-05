using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using UnityEngine;
using UnityEngine.AI;

namespace Luke
{
    /// <summary>
    /// change vfx colour to red. Move towards player pos
    /// </summary>
    public class MoveToPlayerState : AntAIState
    {
        public GameObject owner;
        public NavMeshAgent navMeshAgent;
        public JudasWitnessModel judasWitnessModel;
        public AntAIAgent antAIAgent;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
            antAIAgent = owner.GetComponent<AntAIAgent>();
        }

        public override void Enter()
        {
            base.Enter();

            if (judasWitnessModel.currentPlayerTarget != null)
            {
                navMeshAgent.SetDestination(judasWitnessModel.currentPlayerTarget.transform.position);
            }
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
        }


        
        
    }
}
