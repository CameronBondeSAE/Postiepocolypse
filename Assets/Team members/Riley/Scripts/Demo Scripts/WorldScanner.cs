using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    [Serializable]
    public class Node
    {
        public bool objectFound;
        public Vector2Int nodePos;
    }

    public class WorldScanner : MonoBehaviour
    {
        public Vector3Int gridSize;
        
        public Node[,] gridList;
        [Tooltip("By Default this should be set to 1")]
        public Vector3 gridBoxSize;
        public Vector3 yaBoi;

        void Start()
        {
            gridList = new Node[gridSize.x, gridSize.z];
        }

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
                    gridList[x, z].nodePos = new Vector2Int(x, z);
                    yaBoi = transform.localPosition;
                    if (Physics.CheckBox(new Vector3(x * gridBoxSize.x, 0, z * gridBoxSize.y), gridBoxSize))
                    {
                        gridList[x, z].objectFound = true;
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int z = 0; z < gridSize.z; z++)
                {
                    if (gridList[x, z].objectFound && gridList != null && gridList[x, z] != null)
                    {
                        Gizmos.color = Color.black;
                        Gizmos.DrawWireCube(new Vector3(x * gridBoxSize.x, 0, z * gridBoxSize.y), gridBoxSize);
                    }
                }
            }
        }
    }
}