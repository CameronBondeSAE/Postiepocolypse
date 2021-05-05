using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

namespace Luke
{
    public class PlayerFoundState : AntAIState
    {
        public GameObject owner;
        public JudasWitnessModel judasWitnessModel;
        public JudasWitnessSensor judasWitnessSensor;
        public VisualEffect vfx;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
            vfx = owner.GetComponentInChildren<VisualEffect>();
        }

        public override void Enter()
        {
            base.Enter();

            if (judasWitnessModel.currentPlayerTarget != null)
            {
                Debug.Log("Player found");
                
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
                vfx.SetInt("attackIntensity", judasWitnessModel.playerFoundIntensity);
                vfx.SetFloat("gradientTime", judasWitnessModel.playerFoundGradient);
                
                Finish();
            }

            else
            {
                Finish();
            }
        }
    }
}
