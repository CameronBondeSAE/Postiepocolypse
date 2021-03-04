using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class Node
    {
        public bool objectFound;
    }

    public class AStarPathfinding : MonoBehaviour
    {
        public Vector3Int gridSize;
        
        public Node[,] gridList;
        [Tooltip("By Default this should be set to 1")]
        public Vector3 gridBoxSize;

        public Vector3 yaBoi;

        // Start is called before the first frame update
        void Start()
        {
            gridList = new Node[gridSize.x, gridSize.z];
        }

        // Update is called once per frame
        void Update()
        {
            GridWorldLayout();
        }

        void GridWorldLayout()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int z = 0; z < gridSize.z; z++)
                {
                    gridList[x, z] = new Node();
                    gridList[x, z].objectFound = false;                    
                    yaBoi = transform.localPosition;
                    if (Physics.CheckBox(new Vector3(x * gridBoxSize.x, 0, z * gridBoxSize.y), gridBoxSize))
                    {
                        gridList[x, z].objectFound = true;
                    }
                }
            }

            /*for (int x = 0; x < gridSize.x; x++)
            {
                for (int z = 0; z < gridSize.z; z++)
                {
                    if (Physics.OverlapBox(new Vector3(x*gridSize.x, 0, z*gridSize.z), new Vector3(gridSize.x, gridSize.y, gridSize.z), Quaternion.identity))
                    {
                        // Something is there
                        grid[x, y].isBlocked = true;
                    }
                }
            }*/
        }

        private void OnDrawGizmos()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int z = 0; z < gridSize.z; z++)
                {
                    if (gridList[x, z].objectFound && gridList[x,z] != null)
                    {
                        Gizmos.color = Color.black;
                        Gizmos.DrawWireCube(new Vector3(x * gridBoxSize.x, 0, z * gridBoxSize.y), gridBoxSize);
                    }
                }
            }
        }
    }
}