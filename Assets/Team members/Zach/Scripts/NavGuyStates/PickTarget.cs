using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace ZachFrench
{
    public class PickTarget : AntAIState
    {
        private GameObject parent;
        public Target[] targets;
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            parent = aGameObject;
        }

        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("Looking For Target");

            //Hack
            //Uses an array instead of the a manager to get the to planner work
            targets = FindObjectsOfType<Target>();

            Target target = targets[Random.Range(0, targets.Length)];

            if (target != null)
            {
                parent.GetComponent<NavDudeBody>().target = target;
            }
            
            Finish();
        }
    }
}
