using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Luke
{
    public class FindResourceState : AntAIState
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
            
            Debug.Log("find resource state");
            
            // HACK
            JudasTarget[] targets = FindObjectsOfType<JudasTarget>();
        
            // Pick a random target
            JudasTarget judasTargetPos = targets[Random.Range(0, targets.Length)];
        
            if (judasTargetPos != null)
            {
                owner.GetComponent<JudasWitnessModel>().judasTarget = judasTargetPos;
            }
        
            Finish();
        }
    }
}
