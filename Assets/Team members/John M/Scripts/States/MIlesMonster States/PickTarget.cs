using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;
using ZachFrench;

namespace JonathonMiles
{
    
    public class PickTarget : AntAIState
    {
        private GameObject owner;
        private NavMeshAgent _navMeshAgent;
        private PatrolManager _patrolManager;
        private List<PatrolPoint> targets;

        //create is called on play, when the states are generated
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            _patrolManager = FindObjectOfType<PatrolManager>();

        }
        //enter is called once, when the state is made active on the AI
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
                owner.GetComponent<NavMain>().currentTarget = target;
            }
            
            Finish();
            
        }
        //execute is called repeatedly while the state is active
        
    } 
}

