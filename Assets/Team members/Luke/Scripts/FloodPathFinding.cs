using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class FloodPathFinding : MonoBehaviour
    {
        public Node startingNode;
        public Node currentEvaluatingNode;
        public Node neighbourNode;
        public List<Node> Open;
        public List<Node> Closed;

        // Update is called once per frame
        void Update()
        {
            PathFlooding();
        }

        public void PathFlooding()
        {
            // x and z are the neighbouring x and z nodes along with their diagonals
            for (int x = -1; x < 2; x++)
            {
                for (int z = -1; z < 2; z++)
                {
                    //centre starting node 0,0,0 or desired starting position
                    startingNode = new Node();
                    startingNode.gridPos = new Vector3Int();
                    
                    if (startingNode.isBlocked)
                    {
                        Debug.Log("Blocked startingNode");
                    }

                    else
                    {
                        Closed.Add(startingNode);
                    }
                    
                    //creating the currentNode and adding to the open node list
                    currentEvaluatingNode = new Node();
                    currentEvaluatingNode.gridPos = new Vector3Int(startingNode.gridPos.x + x,0,startingNode.gridPos.z + z);

                    if (currentEvaluatingNode.isBlocked == false)
                    {
                        Open.Add(currentEvaluatingNode);
                    }

                    else
                    {
                        Closed.Add(currentEvaluatingNode);
                    }

                    foreach (Node currentEvaluatingNodes in Open)
                    {
                        currentEvaluatingNodes.gridPos = currentEvaluatingNode.gridPos;
                        
                        neighbourNode = new Node();
                        neighbourNode.gridPos = new Vector3Int(currentEvaluatingNodes.gridPos.x + x,0,currentEvaluatingNodes.gridPos.z + z);

                        if (neighbourNode.isBlocked)
                        {
                            Open.Remove(currentEvaluatingNode);
                            Closed.Add(currentEvaluatingNode);
                        }
                    }
                }
            }
        }

        public void OnDrawGizmos()
        {
            // x and z are the neighbouring x and z nodes along with their diagonals
            for (int x = -1; x < 2; x++)
            {
                for (int z = -1; z < 2; z++)
                {
                    startingNode = new Node();
                    startingNode.gridPos = new Vector3Int();
                    Gizmos.color = Color.white;
                    Gizmos.DrawWireCube(startingNode.gridPos,Vector3.one);
                    
                    currentEvaluatingNode = new Node();
                    currentEvaluatingNode.gridPos = new Vector3Int(startingNode.gridPos.x + x,0,startingNode.gridPos.z + z);
                    
                    if (currentEvaluatingNode.isBlocked)
                    {
                        //the open nodes
                        Gizmos.color = Color.blue;
                        Gizmos.DrawWireCube(new Vector3(x, 0, z),Vector3.one);
                    }

                    else 
                    {
                        //closed nodes
                        Gizmos.color = Color.black;
                        Gizmos.DrawWireCube(new Vector3(x, 0, z),Vector3.one);
                    }

                    foreach (Node currentEvaluatingNodes in Open)
                    {
                        currentEvaluatingNodes.gridPos = currentEvaluatingNode.gridPos;
                        
                        neighbourNode = new Node();
                        neighbourNode.gridPos = new Vector3Int(currentEvaluatingNodes.gridPos.x + x,0,currentEvaluatingNodes.gridPos.z + z);

                        if (neighbourNode.isBlocked)
                        {
                            Gizmos.color = Color.magenta;
                            Gizmos.DrawWireCube(neighbourNode.gridPos, Vector3.one);
                        }

                        else
                        {
                            Gizmos.color = Color.cyan;
                            Gizmos.DrawWireCube(neighbourNode.gridPos, Vector3.one);
                        }
                    }
                    // repeat process??
                }
            }
        }
    }
}
