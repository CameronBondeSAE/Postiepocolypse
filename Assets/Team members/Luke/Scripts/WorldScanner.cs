using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    //put in what information you want from a node (bool for example)
    //TODO: Don't know how to put the gridNodeRef in here properly
    public class Node
    {
        public bool isBlocked;
    }
    public class WorldScanner : MonoBehaviour
    {
        public Vector3Int nodeSize;
        public Transform gridSize;
        public LayerMask groundLayer;
        public Node[,] gridNodeRef;

        // Start is called before the first frame update
        void Start()
        {
            gridNodeRef = new Node[nodeSize.x, nodeSize.z];
            WorldScan();
        }
        
        /// <summary>
        /// TODO: Still need to figure out how to find a starting position for the scan and a finish point
        /// </summary>
        public void WorldScan()
        {
            for (int x = 0; x < nodeSize.x; x++)
            {
                for (int z = 0; z < nodeSize.z; z++)
                {
                    if (Physics.CheckBox(new Vector3(x, 0, z),Vector3.one, Quaternion.identity, groundLayer))
                    {
                        gridNodeRef[x, z].isBlocked = false;
                    }
                }
            }
        }
        
        //Just for visualization
        private void OnDrawGizmos()
        {
            for (int x = 0; x < nodeSize.x; x++)
            {
                for (int z = 0; z < nodeSize.z; z++)
                {
                    if (Physics.CheckBox(new Vector3(x, 0, z),Vector3.one, Quaternion.identity, groundLayer))
                    {
                        Gizmos.color = Color.green;
                        Gizmos.DrawWireCube(new Vector3(x, 0, z), Vector3.one);
                    }
                    else
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawWireCube(new Vector3(x , 0, z ), Vector3.one);
                    }
                }
            }
        }
    }
}
