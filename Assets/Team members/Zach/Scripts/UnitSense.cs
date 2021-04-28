using System.Collections;
using System.Collections.Generic;
using AlexM;
using Anthill.AI;
using Damien;
using UnityEngine;


namespace ZachFrench
{
    public class UnitSense : MonoBehaviour, ISense
    {
        public FOV fov;

        public Transform playerTarget;
        //public List<GameObject> Players;
        
        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            LookingForPlayers();
            aWorldState.BeginUpdate(aAgent.planner);
            aWorldState.Set("Has Target Patrol", aAgent.GetComponent<NavDudeBody>().target != null);
            aWorldState.Set("Is at Target Patrol", false );
            aWorldState.Set("Player Located", playerTarget != null);
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
    }
}
