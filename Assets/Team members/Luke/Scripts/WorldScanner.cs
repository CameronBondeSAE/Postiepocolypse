using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    //put in what information you want from a node (bool for example)
    [Serializable]
    public class Node
    {
        public bool isBlocked;
        public Vector3Int gridPos;
    }
    public class WorldScanner : MonoBehaviour
    {
        public Vector3Int gridSize;
        public LayerMask obstacle;
        public Node[,] gridNodeRef;

        // Start is called before the first frame update
        void Awake()
        {
            gridNodeRef = new Node[gridSize.x, gridSize.z];
            WorldScan();
        }

        /// <summary>
        /// TODO: Still need to figure out how to find a starting position for the scan and a finish point
        /// </summary>
        public void WorldScan()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int z = 0; z < gridSize.z; z++)
                {
                    gridNodeRef[x, z] = new Node();
                    gridNodeRef[x, z].gridPos = new Vector3Int(x,0,z);

                    if (gridNodeRef != null)
                    {
                        gridNodeRef[x, z].isBlocked = false;
                    }

                    if (Physics.CheckBox(new Vector3(x, 0, z), Vector3.one, Quaternion.identity, obstacle))
                    {
                        if (gridNodeRef != null)
                        {
                            gridNodeRef[x, z].isBlocked = true;
                        }
                    }
                }
            }
        }
        
        //Just for debugging and visualization
        private void OnDrawGizmos()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int z = 0; z < gridSize.z; z++)
                {
                    if (gridNodeRef != null && gridNodeRef[x,z].isBlocked)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawWireCube(new Vector3(x, 0, z), Vector3.one);
                    }
                    else
                    {
                        Gizmos.color = Color.green;
                        Gizmos.DrawWireCube(new Vector3(x , 0, z ), Vector3.one);
                    }
                }
            }
        }
    }
}
