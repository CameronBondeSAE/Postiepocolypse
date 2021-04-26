using System.Collections;
using System.Collections.Generic;
using EditedDamien;
using Tanks;
using UnityEngine;

namespace RileyMcGowan
{
    public class MinimapRadarMain : MonoBehaviour
    {
        public GameObject playerMarker;
        public GameObject enemyMarker;
        public GameObject itemMarker;
        private MinimapFOV minimapFOV;
        private int timeToLive = 5;
        private GameObject instantiate;
        private GameObject tempRef;
        public float radarSpeed;
        
        void Start()
        {
            minimapFOV = GetComponent<MinimapFOV>();
        }

        void Update()
        {
            transform.Rotate(0,radarSpeed,0);
            if (minimapFOV.listOfTargets.Count > 0)
            {
                foreach (GameObject targetInFOV in minimapFOV.listOfTargets)
                {
                    if (targetInFOV.layer == 8) //Check layer player
                    {
                        if (targetInFOV.GetComponentInChildren<MarkerHandler>() == null)
                        {
                            SpawnMarkerPlayer(targetInFOV);
                        }
                    }
                    if (targetInFOV.layer == 14) //Check layer enemy
                    {
                        if (targetInFOV.GetComponentInChildren<MarkerHandler>() == null)
                        {
                            SpawnMarkerMonster(targetInFOV);
                        }
                    }
                    if (targetInFOV.layer == 15) //Check layer item
                    {
                        if (targetInFOV.GetComponentInChildren<MarkerHandler>() == null)
                        {
                            SpawnMarkerItem(targetInFOV);
                        }
                    }
                }
            }
        }

        private void SpawnMarkerPlayer(GameObject playerTransform)
        {
            Vector3 playerPos = new Vector3(playerTransform.transform.position.x, 80, playerTransform.transform.position.z);
            instantiate = Instantiate<GameObject>(playerMarker, playerPos, transform.rotation);
            instantiate.transform.parent = playerTransform.transform;
            instantiate.GetComponent<MarkerHandler>().timeToLive = timeToLive;
        }

        private void SpawnMarkerMonster(GameObject enemyTransform)
        {
            Vector3 enemyPos = new Vector3(enemyTransform.transform.position.x, 80, enemyTransform.transform.position.z);
            instantiate = Instantiate<GameObject>(enemyMarker, enemyPos, transform.rotation);
            instantiate.transform.parent = enemyTransform.transform;
            instantiate.GetComponent<MarkerHandler>().timeToLive = timeToLive;
        }
        private void SpawnMarkerItem(GameObject itemTransform)
        {
            Vector3 itemPos = new Vector3(itemTransform.transform.position.x, 80, itemTransform.transform.position.z);
            instantiate = Instantiate<GameObject>(itemMarker, itemPos, transform.rotation);
            instantiate.transform.parent = itemTransform.transform;
            instantiate.GetComponent<MarkerHandler>().timeToLive = timeToLive;
        }
    }
}