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
        public RespawnManager rm;
        public ResourceSpawner rs;
        public Luke.Spawner hellSpawner;

        public int civilianCount = 5;
        public int playerCount = 2;

        // Start is called before the first frame update
        void Awake()
        {
            rm = FindObjectOfType<RespawnManager>();
            rs = FindObjectOfType<ResourceSpawner>();
            hellSpawner = FindObjectOfType<Luke.Spawner>();

            rm.numberOfCivilian = civilianCount;
            rm.numberOfPlayers = playerCount;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
