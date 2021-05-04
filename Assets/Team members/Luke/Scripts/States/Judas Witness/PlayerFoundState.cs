using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

namespace Luke
{
    /// <summary>
    /// change colour to orange
    /// </summary>
    public class PlayerFoundState : AntAIState
    {
        public GameObject owner;
        public JudasWitnessModel judasWitnessModel;
        public VisualEffect vfx;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
            vfx = owner.GetComponentInChildren<VisualEffect>();
            
            vfx.SetInt("attackIntensity", judasWitnessModel.attackIntensity);
            vfx.SetFloat("gradientTime", judasWitnessModel.gradientTime);
        }

        public override void Enter()
        {
            base.Enter();

            if (judasWitnessModel.currentPlayerTarget != null)
            {
                Debug.Log("Player found");
                judasWitnessModel.ResetPlanner();
                
                AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("playerFound", true);
                antAIAgent.worldState.EndUpdate();
            }

            else
            {
                Debug.Log("player not found");
                Finish();
            }
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);

            if (judasWitnessModel.currentPlayerTarget != null)
            {
                judasWitnessModel.gradientTime = .5f * aDeltaTime;
                judasWitnessModel.attackIntensity *= 2;

                Finish();
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
