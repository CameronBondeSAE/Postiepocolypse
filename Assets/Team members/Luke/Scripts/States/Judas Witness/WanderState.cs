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
            Target[] targets = FindObjectsOfType<Target>();
        
            // Pick a random target
            Target targetPos = targets[Random.Range(0, targets.Length)];
        
            if (targetPos != null)
            {
                owner.GetComponent<JudasWitnessModel>().target = targetPos;
            }
        
            Finish();
        }
    }
}
