using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Luke
{
    public class FloodPathFinding : MonoBehaviour
    {
        public Node startingNode;
        public Node currentEvaluatingNode;
        public Node neighbourNode;
        public List<Node> Open;
        public List<Node> Closed;

        public WorldScanner worldScanner;
        
        // Update is called once per frame
        void Start()
        {
            currentEvaluatingNode = new Node();
            startingNode = new Node();
            startingNode.gridPos = new Vector3Int(0, 0, 0);
            InvokeRepeating("PathFlooding",0,1);
            
        }

        public void PathFlooding()
        {
            // x and z are the neighbouring x and z nodes along with their diagonals
            for (int x = -1; x < 2; x++)
            {
                for (int z = -1; z < 2; z++)
                {
                    //creating the currentNode and adding to the open node list
                    int gridPosX = startingNode.gridPos.x + x;
                    int gridPosZ = startingNode.gridPos.z + z;

                    if (gridPosX >=0 && gridPosZ >=0 && worldScanner.gridSize.x > gridPosX && worldScanner.gridSize.z > gridPosZ)
                    {
                        currentEvaluatingNode = worldScanner.gridNodeRef[gridPosX,gridPosZ]; 
                    }
                    else
                    {
                        continue;
                    }
                    
                    if (currentEvaluatingNode.isBlocked)
                    {
                        Debug.Log("Blocked startingNode");
                    }
                    else
                    {
                        Closed.Add(currentEvaluatingNode);
                    }

                    if (currentEvaluatingNode.isBlocked == false)
                    {
                        Open.Add(currentEvaluatingNode);
                    }
                    else
                    {
                        Closed.Add(currentEvaluatingNode);
                    }
                }
            }
            Closed.Add(startingNode);
            startingNode = Open[Random.Range(0, Open.Count)];
        }

        public void OnDrawGizmos()
        {
            // x and z are the neighbouring x and z nodes along with their diagonals

            foreach (Node i in Open)
            {
                if (i.isBlocked)
                {
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawWireCube(i.gridPos, Vector3.one);
                }

                else
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawWireCube(i.gridPos, Vector3.one);
                }
            }
        }
    }
}
