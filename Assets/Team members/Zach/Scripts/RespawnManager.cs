using System;
using System.Collections;
using System.Collections.Generic;
using JonathonMiles;
using Mirror;
using RileyMcGowan;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;


namespace ZachFrench
{


    public class RespawnManager : NetworkBehaviour
    {

        public Vector3 homeSpawn;
        
        //public Vector3 civSpawn;

        public Vector3 playerSpawn;

        public GameObject civilianPrefab;

        public int numberOfCivilian = 4;

        public int numberOfPlayers;

        public Transform baseOrigin;

        public List<GameObject> civilians;

        public List<GameObject> players;

        public PostieNetworkManager postieNetworkManager;

        public Luke.Spawner civSpawn;

        public Canvas gameOver;

		public void Awake()
		{
			
			gameOver.enabled = false;
		}

		// Civilian don't get created instead are still currently part of the list
        public override void OnStartServer()
        {
            base.OnStartServer();
			gameOver.enabled = false;

            if (!isServer)
            {
                return;
            }

            homeSpawn = transform.position;
            postieNetworkManager.newPlayerEvent += PostieNetworkManagerOnNewPlayerEvent;
            postieNetworkManager.playerDisconnectedEvent += PostieNetworkManagerOnPlayerDisconnectedEvent;

            for (int i = 0; i < numberOfCivilian; i++)
            {
                GameObject o = civSpawn.SpawnSingle(civilianPrefab);
                civilians.Add(o);
                // Civs look to center of base for respawning
                Vector3 lookAtWithoutCaringAboutTheY = new Vector3(baseOrigin.position.x, o.transform.position.y, baseOrigin.position.z);
                o.transform.LookAt(lookAtWithoutCaringAboutTheY);
                o.GetComponent<Health>().deathEvent += OndeathEvent;
            }
        }

        private void OndeathEvent(Health health)
        {
            civilians.Remove(health.gameObject);
        }

        private void PostieNetworkManagerOnNewPlayerEvent(GameObject obj)
        {
            obj.GetComponent<Health>().deathEvent += RespawnAfterDeath;
        }
        
        private void PostieNetworkManagerOnPlayerDisconnectedEvent(GameObject obj)
        {
            obj.GetComponent<Health>().deathEvent -= RespawnAfterDeath;
        }

        //Function/event that resets player position
        //Civilian's now get removed from list
        //Need to make sure that when we have a real game object to destroy them here
        private void RespawnAfterDeath(Health obj)
        {
            if (civilians.Count > 0)
            {
                GameObject civilianToDelete = civilians[Random.Range(0,civilians.Count)];
                civilians.Remove(civilianToDelete);


                Inventory inventory = obj.GetComponent<Inventory>();

                // Drop everything
                foreach (ItemBase itemBase in inventory.items)
                {
                    inventory.Drop();
                }

                // obj.transform.position = civilianToDelete.transform.position;
                // obj.transform.rotation = civilianToDelete.transform.rotation;
                // obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                // obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                obj.GetComponent<Health>().currentHealth = civilianToDelete.GetComponent<Health>().currentHealth;
                
				RpcRespawnAfterDeath(obj.gameObject.GetComponent<NetworkIdentity>(), civilianToDelete.transform.position, civilianToDelete.transform.rotation);
				
                // DestroyImmediate(civilianToDelete,true);
                Destroy(civilianToDelete);
                //civilians[numberOfCivilian].GetComponent<Health>().deathEvent -= RespawnAfterDeath;
            }
            else
            {
				if (isServer)
				{
					RpcShowGameOverScreen();
				}
            }
            
        }

		[ClientRpc]
		public void RpcRespawnAfterDeath(NetworkIdentity netID, Vector3 pos, Quaternion rot)
		{
			netID.transform.position                        = pos;
			netID.transform.rotation                        = rot;
			netID.GetComponent<Rigidbody>().velocity        = Vector3.zero;
			netID.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}

		[ClientRpc]
		public void RpcShowGameOverScreen()
		{
			gameOver.enabled = true;
			Debug.Log("You have run out of lives");
		}
	}
}
