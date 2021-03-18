using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class WanderState : AntAIState
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
            
            // HACK
            FakeTarget[] fakeTargets = FindObjectsOfType<FakeTarget>();
        
            // Pick a random target
            FakeTarget fakeTarget = fakeTargets[Random.Range(0, fakeTargets.Length)];
        
            if (fakeTarget != null)
            {
                owner.GetComponent<JudasWitnessModel>().target = fakeTarget;
            }
        
            Finish();
        }
    }
}
