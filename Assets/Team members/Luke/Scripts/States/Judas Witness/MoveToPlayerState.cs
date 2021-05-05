using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

namespace Luke
{
    public class MoveToPlayerState : AntAIState
    {
        public GameObject owner;
        public NavMeshAgent navMeshAgent;
        public JudasWitnessModel judasWitnessModel;
        public AntAIAgent antAIAgent;
        public FOV fov;
        public VisualEffect vfx;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
            antAIAgent = owner.GetComponent<AntAIAgent>();
            fov = owner.GetComponent<FOV>();
            vfx = owner.GetComponentInChildren<VisualEffect>();
        }

        public override void Enter()
        {
            base.Enter();

            if (judasWitnessModel.currentPlayerTarget != null)
            {
                navMeshAgent.speed += judasWitnessModel.speedIncrease;
                vfx.SetInt("attackIntensity", judasWitnessModel.playerFoundIntensity);
                vfx.SetFloat("gradientTime", judasWitnessModel.playerFoundGradient);
                navMeshAgent.SetDestination(judasWitnessModel.currentPlayerTarget.transform.position);
            }
            
            Debug.Log("Moving to player");
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);

            if (judasWitnessModel.currentPlayerTarget != null && navMeshAgent.remainingDistance < .5f)
            {
                vfx.SetInt("attackIntensity", judasWitnessModel.attackingIntensity);
                vfx.SetFloat("gradientTime", judasWitnessModel.attackingGradient);
                
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
                navMeshAgent.speed = judasWitnessModel.patrolSpeed;
                vfx.SetInt("attackIntensity", judasWitnessModel.normalIntensity);
                vfx.SetFloat("gradientTime", judasWitnessModel.normalGradient);
                //setting the world condition
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("atAttackRange", false);
                antAIAgent.worldState.EndUpdate();
            }
        }
    }
}
