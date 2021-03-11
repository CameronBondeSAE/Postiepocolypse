using System;
using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using UnityEngine;


namespace ZachFrench
{


    public class RespawnManager : MonoBehaviour
    {
        public Health health;

        public Vector3 homeSpawn;

        public GameObject player;

        public GameObject civilian;

        public List<GameObject> civilians;
        
        
        // Civilian don't get created instead are still currently part of the list
        void Start()
        {
            homeSpawn = new Vector3(0, 0, 0);

            for (int i = 0; i < 4; i++)
            {
                civilians.Add(civilian);
            }
        }
        
        
        //Event related code for subscribing and unsubscribing 
        private void OnEnable()
        {
            health.deathEvent += RespawnAfterDeath;
        }
        

        private void OnDisable()
        {
            health.deathEvent -= RespawnAfterDeath;
        }
        
        //Function/event that resets player position
        //Civilian's now get removed from list
        //Need to make sure that when we have a real game object to destroy them here
        private void RespawnAfterDeath(Health obj)
        {
            if (civilians.Count > 0)
            {
                civilians.Remove(civilian);
                player.transform.position = homeSpawn;
            }
            else
            {
                Debug.Log("You have run out of lives");
            }
            
        }
        

        
    }
}
