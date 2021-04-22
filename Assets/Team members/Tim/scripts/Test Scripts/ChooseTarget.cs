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
        private PatrolManager patrolManager;
        public List<PatrolPoint> targetList;
        //public PatrolPoint currentTarget;
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            parent = aGameObject;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Finding Target");
            patrolManager = FindObjectOfType<PatrolManager>();
            targetList = patrolManager.paths;
            if (targetList != null)
            {
                parent.GetComponent<SprinterAI>().currentTarget = targetList[Random.Range(0,targetList.Count)];
            }

            Finish();
        }
    }

}
