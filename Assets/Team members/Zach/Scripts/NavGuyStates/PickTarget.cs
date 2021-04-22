using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace ZachFrench
{
    public class PickTarget : AntAIState
    {
        private GameObject parent;
        public PatrolManager patrolManager;
        public List<PatrolPoint> targets;
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            parent = aGameObject;
            //I know we don't like using findObjectOfType however it works when there is only one for now
            patrolManager = FindObjectOfType<PatrolManager>();
        }

        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("Looking For Target");
            //setting the target list to the patrol manager's list of paths 

            if (patrolManager != null)
            {
                targets = patrolManager.paths;
            }

            PatrolPoint target = targets[Random.Range(0, targets.Count - 1)];

            if (target != null)
            {
                parent.GetComponent<NavDudeBody>().target = target;
            }
            
            Finish();
        }
    }
}
