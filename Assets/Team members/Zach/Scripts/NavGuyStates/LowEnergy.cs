using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Tanks;
using UnityEngine;
using UnityEngine.AI;

namespace ZachFrench
{
    public class LowEnergy : AntAIState
    {
        public GameObject parent;
        private NavMeshAgent navMeshAgent;
        public VFXTesting vfx;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            parent = aGameObject;
            navMeshAgent = parent.GetComponent<NavMeshAgent>();
            vfx = parent.GetComponentInChildren<VFXTesting>();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("I have low energy");
            if (vfx != null)
            {
                vfx.stateSwitch = VFXTesting.GradientSwitch.LowEnergy;
            }
            navMeshAgent.isStopped = true;
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            Finish();
        }

        public override void Exit()
        {
            base.Exit();
            /*AntAIAgent antAIAgent = parent.GetComponent<AntAIAgent>();
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("Low Energy", parent.GetComponent<UnitSense>().lowEnergy = false);
            antAIAgent.worldState.EndUpdate();*/
        }
    }
}
