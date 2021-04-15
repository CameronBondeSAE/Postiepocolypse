using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using RileyMcGowan;
using UnityEngine;
using Random = UnityEngine.Random;


namespace ZachFrench
{


    public class RespawnManager : NetworkBehaviour
    {

        public Vector3 homeSpawn;
        
        //public Vector3 civSpawn;

        public Vector3 playerSpawn;

        public GameObject civilianPrefab;

        public int numberOfCivilian = 4;

        public int numberOfPlayers;

        public List<GameObject> civilians;

        public List<GameObject> players;

        public PostieNetworkManager postieNetworkManager;

        public Luke.Spawner civSpawn;
        
        
        // Civilian don't get created instead are still currently part of the list
        public override void OnStartServer()
        {
            base.OnStartServer();

            if (!isServer)
            {
                return;
            }
            homeSpawn = transform.position;
            postieNetworkManager.newPlayerEvent += PostieNetworkManagerOnNewPlayerEvent;
            postieNetworkManager.playerDisconnectedEvent += PostieNetworkManagerOnPlayerDisconnectedEvent;

            for (int i = 0; i < numberOfCivilian; i++)
            {
                civilians.Add(civSpawn.SpawnSingle(civilianPrefab));
            }
        }

        private void PostieNetworkManagerOnNewPlayerEvent(GameObject obj)
        {
            obj.GetComponent<Health>().deathEvent += RespawnAfterDeath;
        }
        
        private void PostieNetworkManagerOnPlayerDisconnectedEvent(GameObject obj)
        {
            obj.GetComponent<Health>().deathEvent -= RespawnAfterDeath;
        }

        //Function/event that resets player position
        //Civilian's now get removed from list
        //Need to make sure that when we have a real game object to destroy them here
        private void RespawnAfterDeath(Health obj)
        {
            if (civilians.Count > 0)
            {
                GameObject civilianToDelete = civilians[Random.Range(0,civilians.Count)];
                Destroy(civilianToDelete);
                civilians.Remove(civilianToDelete);
                obj.transform.position = civilianToDelete.transform.position;
                //civilians[numberOfCivilian].GetComponent<Health>().deathEvent -= RespawnAfterDeath;
            }
            else
            {
                Debug.Log("You have run out of lives");
            }
            
        }
        

        
    }
}
