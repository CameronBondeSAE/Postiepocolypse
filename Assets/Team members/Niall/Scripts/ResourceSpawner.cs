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
        private float RanX;
        private float RanZ;
        private float spawnTime = 1;
        private float spawnDelay= 1;
        public float minRange = -25;
        public float maxRange = 25;

        public override void OnStartServer()
        {
            SpawnCoroutine();
            base.OnStartServer();
        }

        void SpawnCoroutine()
        {
            StartCoroutine("Spawn");
        }


        void Update()
        {
            RanX = Random.Range(minRange, maxRange);
            RanZ = Random.Range(minRange, maxRange);
        }

        IEnumerator Spawn()
        {
            if (isServer)
            {
                for (int i = 0; i < resources; i++)
                {
                    Instantiate(resource, transform.position + new Vector3(RanX, 1, RanZ), Quaternion.identity);
                    yield return new WaitForSeconds(0);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(maxRange, 1, maxRange));
        }
    }
}