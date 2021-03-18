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
            
            Debug.Log("Pick Target");

            Target[] targets = FindObjectsOfType<Target>();

            Target target = targets[Random.Range(0, targets.Length)];

            if (target != null)
            {
                owner.GetComponent<TestAIModel>().target = target;
            }
            
            Finish();
        }
    }
}
