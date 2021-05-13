using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using Mirror;
using UnityEngine;

namespace JonathonMiles
{
    public class ScavengerMain : CreatureBase
    {
        private AntAIAgent _antAIAgent;
        public PatrolPoint currentTarget;
        public FOV fov;
        public GameObject itemTarget;
        public Inventory inventory;
        public Transform spawnPos;
        
        // Start is called before the first frame update
        void Start()
        {
            _antAIAgent = GetComponent<AntAIAgent>();
            spawnPos = transform;
            _antAIAgent.SetGoal("Arrived At Target");
        }

        // Update is called once per frame
        void Update()
        {
            RpcFindItem();
            RpcFullInventroy();
        }

        [ClientRpc]
        void RpcFindItem()
        {
            if (isServer)
            {
                if (fov.listOfTargets.Count != null)
                {
                    if (fov.listOfTargets.Count > 0)
                    {
                        foreach (GameObject item in fov.listOfTargets)
                        {
                            Debug.Log("Item has been found");
                            itemTarget = item;
                            currentTarget = null;
                        }
                    }
                }
            }
        }

        [ClientRpc]
        void RpcFullInventroy()
        {
            if (inventory.inventorySpace == inventory.items.Count)
            {
                currentTarget = null;
                _antAIAgent.worldState.BeginUpdate(_antAIAgent.planner);
                
                _antAIAgent.worldState.Set("Inventory Full", true);
                _antAIAgent.worldState.Set("Has Target", false);
                _antAIAgent.worldState.EndUpdate();
            }
        }
    }
}

