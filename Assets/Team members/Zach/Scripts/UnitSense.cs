using System.Collections;
using System.Collections.Generic;
using AlexM;
using Anthill.AI;
using UnityEngine;


namespace ZachFrench
{
    public class UnitSense : MonoBehaviour, ISense
    {
        public RespawnManager respawnManager;
        //public List<GameObject> Players;
        
        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            aWorldState.BeginUpdate(aAgent.planner);
            aWorldState.Set("Has Target Patrol", aAgent.GetComponent<NavDudeBody>().target != null);
            aWorldState.Set("Is at Target Patrol", false );
            aWorldState.Set("Player Located", aAgent.GetComponent<NavDudeBody>().playerTarget != null);
            aWorldState.EndUpdate();
        }

        /*public void LookingForPlayers()
        {
            respawnManager = FindObjectOfType<RespawnManager>();
            Players = respawnManager.players;
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            
            //if(hit.collider = )
        }*/
    }
}
