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
		private GameObject   resource;
		public  GameObject[] resourcePrefabs;

		public float groundOffset = 2f;

		[Header("Amount of Resources Spawned per Wave.")]
		public int resources = 5;

		[Header("Amount of Waves/Times to Spawn Resources")]
		public int waves = 1;

		[Header("Time between spawn waves (Seconds)")]
		public int spawnRate;


		[Space]
		public Transform[] resourceSpawnpoints;

		[Header("Spawn Point Radius")]
		public float rangeRad = 25;

		[Header("Bool if spawning is enabled")]
		public bool spawning;

		private int spawnLocationIndex;

		public override void OnStartServer()
		{
			base.OnStartServer();
			SpawnCoroutine();
		}

		void SpawnCoroutine()
		{
			StartCoroutine("Spawn");
		}


		IEnumerator Spawn()
		{
			if (isServer && spawning)
			{
				for (int w = 0; w < waves; w++)
				{
					for (int i = 0; i < resources; i++)
					{
						// spawnLocation = 0;
						// for (int r = 0; r < resourceSpawnpoints.Length; r++)
						// {
						// if (resourceSpawnpoints[spawnLocation] != null)
						// {
						resource = resourcePrefabs[Random.Range(0, resourcePrefabs.Length)];

						spawnLocationIndex = Random.Range(0, resourceSpawnpoints.Length);
						
						// TODO Cam hack, this doesn't allow random spawning AND/OR fixed resource spawn points. It uses both at the same time and spawns underground etc
						// GameObject newGO = Instantiate(resource, resourceSpawnpoints[spawnLocation].transform.position + Random.insideUnitSphere * rangeRad + new Vector3(0, groundOffset, 0), Quaternion.identity);
						GameObject newGO = Instantiate(resource, resourceSpawnpoints[spawnLocationIndex].transform.position + new Vector3(0, groundOffset, 0), Quaternion.identity);
						NetworkServer.Spawn(newGO);


						// if (spawnLocation > resourceSpawnpoints.Length)
						// {
							// spawning      = false;
							// spawnLocation = 0;
						// }
						// }

						// spawnLocation++;
						// }
					}

					yield return new WaitForSeconds(spawnRate);
				}
			}
		}

		private void OnDrawGizmos()
		{
			if (resourceSpawnpoints != null)
				foreach (var t in resourceSpawnpoints)
				{
					if (t != null)
					{
						Gizmos.DrawWireSphere(t.position, rangeRad);
					}
				}
		}
	}
}