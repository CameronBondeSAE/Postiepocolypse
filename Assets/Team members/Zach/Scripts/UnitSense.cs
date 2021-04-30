using System.Collections;
using System.Collections.Generic;
using AlexM;
using Anthill.AI;
using Damien;
using TimPearson;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


namespace ZachFrench
{
    public class UnitSense : MonoBehaviour, ISense
    {
        public FOV fov;

        public Energy Energy;

        public bool lowEnergy;

        public Transform playerTarget;
        //public List<GameObject> Players;
        public NavMeshAgent NavMeshAgent;
        
        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            LookingForPlayers();
            LowEnergy();
            aWorldState.BeginUpdate(aAgent.planner);
            aWorldState.Set("Has Target Patrol", aAgent.GetComponent<NavDudeBody>().target != null);
            aWorldState.Set("Is at Target Patrol", false );
            aWorldState.Set("Player Located", playerTarget != null);
            aWorldState.Set("Low Energy", lowEnergy);
            aWorldState.EndUpdate();
        }

        public void LookingForPlayers()
        {
            if (fov.listOfTargets.Count > 0)
            {
                foreach (GameObject target in fov.listOfTargets)
                {
                    float distance = Vector3.Distance(transform.position, target.transform.position);
                    if (distance < 20f)
                    {
                        playerTarget = target.transform;
                    }
                    else
                    {
                        playerTarget = null;
                    }
                }
            }
            else
            {
                playerTarget = null;
            }
        }

        public void LowEnergy()
        {
            if (Energy.CurrentAmount <= 5f)
            {
                lowEnergy = true;
            }
            else if (Energy.CurrentAmount > Energy.MaxAmount - 1f)
            {
                lowEnergy = false;
                NavMeshAgent.isStopped = false;
            }
        }
        
    }
}
