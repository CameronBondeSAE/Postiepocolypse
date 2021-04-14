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
        
        [Header("Ray-casting")]
        public float ySpawnGroundOffset = 1f;
        public float yAdjustablePosition;
        public void Start()
        {
            if (spawnOnStart)
            {
                SpawnSetPrefabs();
            }
        }

        //spawn with the amount numberOfPrefabs with a range of different types of prefabs
        public void SpawnSetPrefabs()
        {
            GameObject currentPrefab = new GameObject();
            
            //position at each spawn point
            for (int i = 0; i < setsOfPrefabs; i++)
            {
                //hard coded height for the raycast to the ground
                Vector3 position = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange),
                    yAdjustablePosition + transform.position.y, Random.Range(-spawnRange, spawnRange));

                currentPrefab = SpawnPrefab(currentPrefab, position);
            }
        }

        /// <summary>
        /// Use this function if you want to call this functionality for a single prefab
        /// </summary>
        public GameObject SpawnPrefab(GameObject currentPrefab, Vector3 position)
        {
            //loop through prefabs list
            for (int j = 0; j < prefabs.Length; j++)
            {
                //set current random on the loop
                int randomPrefab = Random.Range(0, prefabs.Length);

                if (randomSpawn)
                {
                    currentPrefab = Instantiate(prefabs[randomPrefab], position, Quaternion.identity);
                }
                else
                {
                    currentPrefab = Instantiate(prefabs[j], position, Quaternion.identity);
                }
            }

            //raycast hit spawn pos
            RaycastHit hitInfo;
            Physics.Raycast(new Ray(position, Vector3.down), out hitInfo);
            if (hitInfo.collider)
            {
                currentPrefab.transform.position = hitInfo.point + new Vector3(0, ySpawnGroundOffset, 0);
            }
            //just in case the prefabs spawn in the ground
            else
            {
                Destroy(currentPrefab);
            }

            return currentPrefab;
        }
    }
}
