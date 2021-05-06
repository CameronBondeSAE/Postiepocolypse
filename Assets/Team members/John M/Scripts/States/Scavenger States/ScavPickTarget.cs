using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine.AI;
using ZachFrench;
using UnityEngine;

namespace JonathonMiles
{
    public class ScavPickTarget : AntAIState
    {
        private GameObject owner;
        private NavMeshAgent _navMeshAgent;
        private PatrolManager _patrolManager;
        private List<PatrolPoint> targets;
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            _patrolManager = FindObjectOfType<PatrolManager>();

        }

        public override void Enter()
        {
            base.Enter();
            if (_patrolManager != null)
            {
                targets = _patrolManager.paths;
            }
            PatrolPoint target = targets[Random.Range(0, targets.Count)];
            if (target != null)
            {
                owner.GetComponent<ScavengerMain>().currentTarget = target;
            }
            Finish();
            
        }
    }
}

