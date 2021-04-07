using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Niall
{
    public class ResourceSpawner : NetworkBehaviour
    {   
        
         public GameObject resource;
         
        [Header("Amount of Resources Spawned per wave.")]
        public int resources = 5;
        [Header("Time between spawn waves (Seconds)")]
        public int spawnRate;
        [Space]
        public Transform[] resourceSpawnpoints;
        
        [Header("Spawn Point Radius")]
        public float rangeRad = 25;
        [Header("Bool if spawning is enabled")]
        public bool spawning;
        
       private int spawnLocation;
        public override void OnStartServer()
        {
            base.OnStartServer();
            SpawnCoroutine();
            
        }

        void SpawnCoroutine()
        {
            StartCoroutine("Spawn");
        }

        

        IEnumerator Spawn()
        {
            if (isServer)
            {
                if (spawning)
                {
                    for (int i = 0; i < resources; i++)
                    {
                        spawnLocation = 0;
                        for (int r = 0; r < resourceSpawnpoints.Length; r++)
                        {
                            if (resourceSpawnpoints[spawnLocation] != null)
                            {
                                GameObject newGO = Instantiate(resource,
                                    resourceSpawnpoints[spawnLocation].transform.position +
                                    Random.insideUnitSphere * rangeRad, Quaternion.identity);
                                NetworkServer.Spawn(newGO);
                                spawnLocation++;

                                if (spawnLocation > resourceSpawnpoints.Length)
                                {
                                    spawning = false;
                                    spawnLocation = 0;
                                }
                            }
                        }
                        yield return new WaitForSeconds(spawnRate);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (resourceSpawnpoints != null)
                foreach (var t in resourceSpawnpoints)
                {
                    if (t != null)
                    {
                        Gizmos.DrawWireSphere(t.position, rangeRad);
                    }
                }
                    
        }
    }
}