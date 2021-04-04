using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class TestFindPosState : AntAIState
    {
        public GameObject owner;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
        }

        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("Picking state");

            JudasTarget[] targets = FindObjectsOfType<JudasTarget>();

            JudasTarget judasTarget = targets[Random.Range(0, targets.Length)];

            if (judasTarget != null)
            {
                owner.GetComponent<TestAIModel>().judasTarget = judasTarget;
            }
            
            Finish();
        }
    }
}
