using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

namespace Luke
{
    public class PlayerFoundState : AntAIState
    {
        public GameObject owner;
        public JudasWitnessModel judasWitnessModel;

        /// <summary>
        ///  TODO This whole state is skipped by a sensor check!!!!!!!!!! 
        /// </summary>
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
        }

        public override void Enter()
        {
            base.Enter();

            if (judasWitnessModel.currentPlayerTarget != null)
            {
                Debug.Log("Player found");
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

            Finish();
        }
    }
}
