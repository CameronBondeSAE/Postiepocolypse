using System.Collections;
using System.Collections.Generic;
using AJ;
using Mirror;
using Niall;
using UnityEngine;
using ZachFrench;

namespace ZachFrench
{


    public class GamemodeManager : NetworkBehaviour
    {
        // Make sure that there are already the other managers in the scene as these only grab them and don't spawn them
        private RespawnManager respawnManager;
        private ResourceSpawner resourceSpawner;
        public Luke.Spawner portalSpawner;
        //These are just set values for testing and can be altered in code or in the scene 
        public int civilianCount = 5;
        public int playerCount = 2;
        public int portalCount = 3;
        public float portalSpawnRange = 50;

        // Start is called before the first frame update
        public override void OnStartServer()
        {
            base.OnStartServer();

            if (!isServer)
            {
                return;
            }
            //Finds the other managers 
            respawnManager = FindObjectOfType<RespawnManager>();
            resourceSpawner = FindObjectOfType<ResourceSpawner>();

            //this sets the values within the managers to the values located in the Gamemode Manager
            //first is the respawn manager 
            respawnManager.numberOfCivilian = civilianCount;
            respawnManager.numberOfPlayers = playerCount;
            //PortalSpawner is next 
            //Setting the amount of portals to spawn
            portalSpawner.setsOfPrefabs = portalCount;
            //Setting the spawn offset of spawners
            portalSpawner.spawnRange = portalSpawnRange;
            //checking for bool, to make sure that we can spawn/start spawning the portals
            if (portalSpawner.spawnOnStart == false)
            {
                portalSpawner.spawnOnStart = true;
            }
        }
    }
}
