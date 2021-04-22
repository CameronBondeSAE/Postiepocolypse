using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using ZachFrench;

namespace TimPearson
{
    public class ChooseTarget : AntAIState
    {
        private GameObject parent;
        private PatrolManager targets;
        public PatrolPoint currentTarget;
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            parent = aGameObject;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Finding Target");
            targets = FindObjectOfType<PatrolManager>();
            currentTarget = targets.paths[Random.Range(0, targets.paths.Count)];
            if (currentTarget != null)
            {
                parent.GetComponent<SprinterAI>().target = targets;
            }

            Finish();
        }
    }

}
