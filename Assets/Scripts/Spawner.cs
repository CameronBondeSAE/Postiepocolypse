using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Sirenix.Utilities;
using UnityEngine;
using ZachFrench;
using Random = UnityEngine.Random;

namespace Luke
{
    public class Spawner : NetworkBehaviour
    {
        [Tooltip("Multiple amounts of each prefab in the list")]
        public int setsOfPrefabs = 1;
        public GameObject[] prefabs;
        public float spawnRange;
        public bool spawnOnStart;
        [Tooltip("Randomly chooses prefabs within the prefabs list")]
        public bool randomSpawn;
        [Header("Spawn Ray-casting")]
        public float ySpawnGroundOffset = 1f;
        public float yAdjustablePosition;
        public float yGroundTestOffset = 5f;
        public bool spawnOnPatrolPoints;
        public PatrolManager patrolManager;
        public override void OnStartServer()
        {
            base.OnStartServer();
            
            if (patrolManager == null)
            {
                patrolManager = FindObjectOfType<PatrolManager>();
            }
            
            if (spawnOnStart)
            {
                SpawnMultipleSets();
            }
        }

        /// <summary>
        /// TODO: Need to figure out how to have the spawn ignore everything except the ground and also the option to part the spawns further away.
        /// </summary>
        //spawn with the amount numberOfPrefabs with a range of different types of prefabs
        public void SpawnMultipleSets()
        {
            //multiple sets of prefabs
            for (int i = 0; i < setsOfPrefabs; i++)
            {
                SpawnSetPrefab();
            }
        }

        public void SpawnSetPrefab()
        {
            //spawn a single set
            for (int j = 0; j < prefabs.Length; j++)
            {
                SpawnSingle(prefabs[j]);
            }
        }

        /// <summary>
        /// Use this function if you want to call this functionality for a single prefab
        /// </summary>
        public GameObject SpawnSingle(GameObject prefab)
        {
            GameObject spawnedInstance = null;
            
            if (isServer)
            {
                //random position for spawn + an adjustable y position in case of very large prefabs
                Vector3 randomPosition = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange),
                    transform.position.y + yAdjustablePosition, Random.Range(-spawnRange, spawnRange));

                List<PatrolPoint> spawnPatrolPositions = patrolManager.paths;
                PatrolPoint patrolPosition = spawnPatrolPositions[Random.Range(0, patrolManager.paths.Count)];

                if (spawnOnPatrolPoints && patrolManager != null)
                {
                    foreach (PatrolPoint patrolPoint in spawnPatrolPositions)
                    {
                        while (patrolPosition != patrolPoint)    
                        {
                            SpawnPosition(patrolPosition.transform.position, prefab);
                            spawnPatrolPositions.Remove(patrolPoint);
                            break;
                        }
                    }
                }

                else
                {
                    SpawnPosition(randomPosition, prefab);
                }
                ///TODO: Keep on trying to find a surface instead of deleting
                spawnedInstance = prefab;
                return spawnedInstance;
            }
            else
            {
                return null;
            }
        }

        public void SpawnPosition(Vector3 position, GameObject prefab)
        {
            //set current random on the loop
            int randomPrefab = Random.Range(0, prefabs.Length);

            prefab = prefabs[randomPrefab];

            if (randomSpawn)
            { 
                Instantiate(prefab, position, transform.rotation);
                NetworkServer.Spawn(prefab);
            }
            else
            {
                Instantiate(prefab, position, transform.rotation);
                NetworkServer.Spawn(prefab);
            }
            
            //raycast hit spawn pos
            RaycastHit hitInfo;
            Physics.Raycast(new Ray(position + new Vector3(0, yGroundTestOffset, 0),
                -transform.up), out hitInfo);
            if (hitInfo.collider)
            {
                prefab.transform.position = hitInfo.point + new Vector3(0, ySpawnGroundOffset, 0);
                Debug.Log(hitInfo.collider.gameObject.name);
            }
            //just in case the prefabs spawn in the ground
            else
            {
                Destroy(prefab);   
                Debug.Log("Failed Spawn");
            }
        }
    }
}