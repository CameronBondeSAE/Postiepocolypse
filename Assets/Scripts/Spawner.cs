using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Luke
{
    public class Spawner : MonoBehaviour
    {
        public int numberOfPrefabs;
        public GameObject[] prefabs;
        public float      spawnRange;
        public float    ySpawnGroundOffset = 1f;
        public bool spawnOnStart;
        public void Start()
        {
            if (spawnOnStart)
            {
                SpawnPrefabs();
            }
        }

        //spawn with the amount numberOfPrefabs with a range of prefabs
        public void SpawnPrefabs()
        {
            //position at each spawn point
            for (int i = 0; i < numberOfPrefabs; i++)
            {
                //hard coded height for the raycast to the ground
                Vector3 position = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 100, Random.Range(-spawnRange, spawnRange));
                
                //run through randoms
                int randomPrefab = Random.Range(0, prefabs.Length);

                //set current random on the loop
                GameObject currentPrefab = Instantiate(prefabs[randomPrefab], position, Quaternion.identity);

                //raycast hit spawn pos
                RaycastHit hitInfo;
                Physics.Raycast(new Ray(position, Vector3.down), out hitInfo, 200f);
                if (hitInfo.collider)
                {
                    currentPrefab.transform.position = hitInfo.point + new Vector3(0,ySpawnGroundOffset, 0);
                }
                //just in case the prefabs spawn in the ground
                else
                {
                    Destroy(currentPrefab);
                }
            }
        }
    }
}
