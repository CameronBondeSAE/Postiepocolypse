using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class WorldScanner : MonoBehaviour
    {
        public Vector3Int gridSize;
        public Node[,] gridNodeRef;

        //put in what information you want from a node (bool for example)
        public class Node
        {
            private bool isBlocked;
        }
        
        // Start is called before the first frame update
        void Start()
        {
            gridNodeRef = new Node[gridSize.x,gridSize.z];
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void WorldScan()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int z = 0; z < gridSize.z; z++)
                {
                    if (Physics.CheckBox(new Vector3(x * gridSize.x, 0, z * gridSize.z),gridSize))
                    {
                        gridNodeRef[x, z] = new Node();
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int z = 0; z < gridSize.y; z++)
                {
                    if (Physics.CheckBox(new Vector3(x * gridSize.x, 0, z * gridSize.z),gridSize))
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawWireCube(new Vector3(x * gridSize.x, 0, z * gridSize.z), gridSize);
                    }
                    else
                    {
                        Gizmos.color = Color.green;
                        Gizmos.DrawWireCube(new Vector3(x * gridSize.x, 0, z * gridSize.z), gridSize);
                    }
                    
                }
            }
        }
    }
}
