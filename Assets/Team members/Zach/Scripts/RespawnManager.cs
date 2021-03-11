using System;
using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using Tanks;
using UnityEngine;
using Random = UnityEngine.Random;


namespace ZachFrench
{


    public class RespawnManager : MonoBehaviour
    {

        public Vector3 homeSpawn;
        
        public Vector3 civSpawn;

        public GameObject playerPrefab;

        public GameObject civilianPrefab;

        public int numberOfCivilian;

        public List<GameObject> civilians;

        public List<GameObject> players;
        
        
        // Civilian don't get created instead are still currently part of the list
        void Start()
        {
            homeSpawn = new Vector3(0, 0, 0);
            numberOfCivilian = 4;
            
            for (int i = 0; i < numberOfCivilian; i++)
            {
                civSpawn = new Vector3(Random.Range(0,10), 0, Random.Range(0,10));
                civilians.Add(Instantiate(civilianPrefab,civSpawn,new Quaternion(0,0,0,0)));
                //civilians[i].GetComponent<Health>().deathEvent += RespawnAfterDeath;
            }

            /*for (int i = 0; i < 3; i++)
            {
                players.Add(Instantiate(player,homeSpawn,new Quaternion(0,0,0,0)));
                players[i].GetComponent<Health>().deathEvent += RespawnAfterDeath;
            }*/
            
            foreach (GameObject o in players)
            {
                o.GetComponent<Health>().deathEvent += RespawnAfterDeath;
            }
        }

        //Function/event that resets player position
        //Civilian's now get removed from list
        //Need to make sure that when we have a real game object to destroy them here
        private void RespawnAfterDeath(Health obj)
        {
            if (civilians.Count > 0)
            {
                GameObject civilianToDelete = civilians[Random.Range(0,civilians.Count)];
                Destroy(civilianToDelete);
                civilians.Remove(civilianToDelete);
                obj.transform.position = civilianToDelete.transform.position;
                //civilians[numberOfCivilian].GetComponent<Health>().deathEvent -= RespawnAfterDeath;
            }
            else
            {
                Debug.Log("You have run out of lives");
            }
            
        }
        

        
    }
}
