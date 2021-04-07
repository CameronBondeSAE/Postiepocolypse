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
        private Luke.Spawner hellSpawner;
        //These are just set values for testing and can be altered in code or in the scene 
        public int civilianCount = 5;
        public int playerCount = 2;
        public int creatureCount = 5;

        // Start is called before the first frame update
        void Awake()
        {
            //Finds the other managers 
            rm = FindObjectOfType<RespawnManager>();
            rs = FindObjectOfType<ResourceSpawner>();
            hellSpawner = FindObjectOfType<Luke.Spawner>();
            
            //this sets the values within the managers to the values located in the Gamemode Manager
            rm.numberOfCivilian = civilianCount;
            rm.numberOfPlayers = playerCount;
            hellSpawner.numberOfCreatures = creatureCount;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
