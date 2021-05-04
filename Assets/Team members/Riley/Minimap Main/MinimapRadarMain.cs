using System.Collections;
using System.Collections.Generic;
using EditedDamien;
using Mirror;
using Tanks;
using UnityEngine;

namespace RileyMcGowan
{
    public class MinimapRadarMain : NetworkBehaviour
    {
        //Main Vars
        private MinimapFOV minimapFOV;
        private int timeToLive = 10;
        private GameObject instantiate;
        private GameObject tempRef;
        public float radarSpeed;
        //Changeable Vars (Add a new for each type of marker)
        public GameObject playerMarker;
        public GameObject enemyMarker;
        public GameObject itemMarker;
        
        
        void Start()
        {
            minimapFOV = GetComponent<MinimapFOV>();
        }

        void Update()
        {
            if (isClient)
            {
                RpcResetRotation();
                if (minimapFOV.listOfTargets.Count > 0)
                {
                    foreach (GameObject targetInFOV in minimapFOV.listOfTargets)
                    {
                        if (targetInFOV.GetComponentInChildren<MarkerHandler>() == null)
                        {
                            if (targetInFOV.layer == 8)
                            {
                                SpawnMarker(targetInFOV, playerMarker);
                            }
                            if (targetInFOV.layer == 14)
                            {
                                SpawnMarker(targetInFOV, enemyMarker);
                            }
                            if (targetInFOV.layer == 15)
                            {
                                SpawnMarker(targetInFOV, itemMarker);
                            }
                        }
                    }
                }
            }
        }

        private void SpawnMarker(GameObject currentTransform, GameObject markerToSpawn)
        {
            Vector3 currentPos = new Vector3(currentTransform.transform.position.x, 80, currentTransform.transform.position.z);
            instantiate = Instantiate<GameObject>(markerToSpawn, currentPos, transform.rotation);
            instantiate.transform.parent = currentTransform.transform;
            instantiate.GetComponent<MarkerHandler>().timeToLive = timeToLive;
        }
        
        [ClientRpc]
        private void RpcResetRotation()
        {
            transform.Rotate(0,radarSpeed,0);
        }
    }
}