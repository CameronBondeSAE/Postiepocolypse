using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anthill.AI;
using Damien;
using UnityEngine.AI;
using UnityEngine.VFX;

namespace Luke
{
    public class AttackPlayerState : AntAIState
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
            
            Debug.Log("Enter attack player state");
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            
            if (fov.listOfTargets.Count <= 0)
            {
                judasWitnessModel.currentPlayerTarget = null;
                navMeshAgent.speed = judasWitnessModel.patrolSpeed;
                //setting the world condition
                vfx.SetInt("attackIntensity", judasWitnessModel.normalIntensity);
                vfx.SetFloat("gradientTime", judasWitnessModel.normalGradient);
                
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("atAttackRange", false);
                antAIAgent.worldState.EndUpdate();
            }
            
            if (judasWitnessModel.currentPlayerTarget == null)
            {
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("playerFound", false);
                antAIAgent.worldState.EndUpdate();
                
                Finish();
            }
        }
    }
}
