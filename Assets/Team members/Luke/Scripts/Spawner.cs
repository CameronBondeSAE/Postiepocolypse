using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Luke
{
    public class Spawner : MonoBehaviour
    {
        public int numberOfCreatures;
        public GameObject[] creaturePrefabs;
        public float      spawnRange;
        public float    ySpawnOffset = 1f;
        public void Start()
        {
            SpawnCreatures();
        }

        //spawn an numberOfCreatures on hell portal with a range of creatureTypes
        public void SpawnCreatures()
        {
            //position at each spawn point
            for (int i = 0; i < numberOfCreatures; i++)
            {
                Vector3 position = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 100, Random.Range(-spawnRange, spawnRange));
                
                //run through randoms
                int randomPrefab = Random.Range(0, creaturePrefabs.Length);

                //set current random on the loop
                GameObject currentPrefab = Instantiate(creaturePrefabs[randomPrefab], position, Quaternion.identity);

                //raycast hit spawn pos
                RaycastHit hitInfo;
                Physics.Raycast(new Ray(position, Vector3.down), out hitInfo, 200f);
                if (hitInfo.collider)
                {
                    currentPrefab.transform.position = hitInfo.point + new Vector3(0,ySpawnOffset, 0);
                }
                else
                {
                    Destroy(currentPrefab);
                }
            }
        }
    }
}
