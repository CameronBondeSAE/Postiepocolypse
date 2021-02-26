using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Luke
{
    public class CreatureManager : MonoBehaviour
    {
        public int numberOfCreatures;
        public GameObject[] creaturePrefabs;
        public Transform[] creatureSpawnPoints;


        // private static CreatureManager instance;
        //
        // public static CreatureManager Instance
        // {
        //     get
        //     {
        //         new GameObject("CreatureManager");
        //         return instance;
        //     }
        // }
        //
        // void Awake()
        // {
        //     //checking to see if there is a manager already there
        //     if (instance == null && instance != this)
        //     {
        //         Destroy(this.gameObject);
        //         return;
        //     }
        //     instance = this;
        //     //won't delete, continue to next scene
        //     DontDestroyOnLoad(this.gameObject);
        // }

        public void Start()
        {
            SpawnCreatures();
        }

        //spawn an numberOfCreatures on hell portal with a range of creatureTypes
        public void SpawnCreatures()
        {
            //position at each spawn point
            for(int i = 0; i < numberOfCreatures; i++)
            {
                //run through randoms
                int randomPrefab = Random.Range(0, creaturePrefabs.Length);
                int randomSpawnPoint = Random.Range(0, creatureSpawnPoints.Length);
                
                //set current random on the loop
                GameObject currentPrefab = creaturePrefabs[randomPrefab];
                Transform currentSpawnPoint = creatureSpawnPoints[randomSpawnPoint];
                
                //spawn
                Instantiate(currentPrefab,currentSpawnPoint);
            }

        }
    }
}
