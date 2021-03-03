using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class Spawner : MonoBehaviour
    {
        public int numberOfCreatures;
        public GameObject[] creaturePrefabs;
        public Transform[] creatureSpawnPoints;

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
                //run through randoms
                int randomPrefab = Random.Range(0, creaturePrefabs.Length);
                int randomSpawnPoint = Random.Range(0, creatureSpawnPoints.Length);

                //set current random on the loop
                GameObject currentPrefab = creaturePrefabs[randomPrefab];
                Transform currentSpawnPoint = creatureSpawnPoints[randomSpawnPoint];

                //spawn
                Instantiate(currentPrefab, currentSpawnPoint);
            }

        }
    }
}
