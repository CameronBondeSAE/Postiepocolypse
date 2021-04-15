using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Luke
{
    public class Spawner : MonoBehaviour
    {
        public int setsOfPrefabs;
        public GameObject[] prefabs;
        public float spawnRange;
        public bool spawnOnStart;
        public bool randomSpawn;
        
        [Header("Spawn Ray-casting")]
        public float ySpawnGroundOffset = 1f;
        public float yAdjustablePosition;
        public LayerMask groundLayer;
        public float yGroundTestOffset = 5f;
        public void Start()
        {
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
            GameObject spawnedInstance;
            //set current random on the loop
            int randomPrefab = Random.Range(0, prefabs.Length);

            //random position for spawn + an adjustable y position in case of very large prefabs
            Vector3 position = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange),
                transform.position.y + yAdjustablePosition, Random.Range(-spawnRange, spawnRange));
            
            if (randomSpawn)
            {
                spawnedInstance = Instantiate(prefabs[randomPrefab], position, transform.rotation);
            }
            else
            {
                spawnedInstance = Instantiate(prefab, position, transform.rotation);
            }

            //raycast hit spawn pos
            RaycastHit hitInfo;
            Physics.Raycast(new Ray(position + new Vector3(0,yGroundTestOffset,0),
                -transform.up), out hitInfo);
            if (hitInfo.collider)
            {
                spawnedInstance.transform.position = hitInfo.point + new Vector3(0, ySpawnGroundOffset, 0);
                Debug.Log(hitInfo.collider.gameObject.name);
            }
            //just in case the prefabs spawn in the ground
            else
            {
                Destroy(spawnedInstance);
                Debug.Log("Failed Spawn");
            }
            ///TODO: Keep on trying to find a surface instead of deleting
            return spawnedInstance;
        }
    }
}
