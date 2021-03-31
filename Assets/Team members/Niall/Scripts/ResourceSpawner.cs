using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Niall
{
    public class ResourceSpawner : NetworkBehaviour
    {
        public int resources = 5;
        public GameObject resource;

        public Transform[] resourceSpawnpoint;
        private float RanX;
        private float RanZ;
        private float spawnTime = 1;
        private float spawnDelay= 1;
        public float rangeRad = 25;

        private bool spawning;

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
                while (spawning)
                {
                    for (int i = 0; i < resources; i++)
                    {
                        RanX = Random.Range(-rangeRad, rangeRad);
                        RanZ = Random.Range(-rangeRad, rangeRad);

                        GameObject newGO = Instantiate(resource, transform.position + new Vector3(RanX, 10, RanZ),
                            Quaternion.identity);
                        NetworkServer.Spawn(newGO);
                        yield return new WaitForSeconds(0);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(rangeRad*2, 1, rangeRad*2));
        }
    }
}