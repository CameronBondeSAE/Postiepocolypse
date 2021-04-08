using System.Collections;
using System.Collections.Generic;
using AJ;
using Niall;
using UnityEngine;
using ZachFrench;

namespace ZachFrench
{


    public class GamemodeManager : MonoBehaviour
    {
        // Make sure that there are already the other managers in the scene as these only grab them and don't spawn them
        private RespawnManager rm;
        private ResourceSpawner rs;
        public Luke.Spawner portalSpawner;
        //These are just set values for testing and can be altered in code or in the scene 
        public int civilianCount = 5;
        public int playerCount = 2;
        public int portalCount = 3;
        public float portalOffset = 20;

        // Start is called before the first frame update
        void Awake()
        {
            //Finds the other managers 
            rm = FindObjectOfType<RespawnManager>();
            rs = FindObjectOfType<ResourceSpawner>();
            portalSpawner = FindObjectOfType<Luke.Spawner>();
          
            //this sets the values within the managers to the values located in the Gamemode Manager
            //first is the respawn manager 
            rm.numberOfCivilian = civilianCount;
            rm.numberOfPlayers = playerCount;
            //PortalSpawner is next 
            //Setting the amount of portals to spawn
            portalSpawner.numberOfPrefabs = portalCount;
            //Setting the spawn offset of spawners
            portalSpawner.spawnRange = portalOffset;
            //checking for bool, to make sure that we can spawn/start spawning the portals
            if (portalSpawner.spawnOnStart == false)
            {
                portalSpawner.spawnOnStart = true;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
