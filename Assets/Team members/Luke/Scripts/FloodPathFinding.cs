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
        public List<Node> Open;
        public List<Node> Closed;
        public WorldScanner worldScanner;
        
        void Start()
        {
            currentEvaluatingNode = new Node();
            startingNode = new Node();
            startingNode.gridPos = new Vector3Int(0, 0, 0);
            InvokeRepeating("PathFlooding",0,.1f);
            
        }

        //TODO: maybe make this an IEnumarator?
        public void PathFlooding()
        {
            // x and z are the neighbouring x and z nodes along with their diagonals
            for (int x = -1; x < 2; x++)
            {
                for (int z = -1; z < 2; z++)
                {
                    //variables for startingNode x and z pos
                    int gridPosX = startingNode.gridPos.x + x;
                    int gridPosZ = startingNode.gridPos.z + z;

                    // The array cannot take negative numbers so you have to check both the x and z is greater than zero and less than the grid size
                    if (gridPosX >=0 && gridPosZ >=0 && worldScanner.gridSize.x > gridPosX && worldScanner.gridSize.z > gridPosZ)
                    {
                        currentEvaluatingNode = worldScanner.gridNodeRef[gridPosX,gridPosZ]; 
                    }
                    else
                    {
                        //breaks out of the current loop
                        continue;
                    }

                    //To see if the startingNode is a dud
                    if (startingNode.isBlocked)
                    {
                        Debug.Log("Blocked startingNode");
                    }

                    //checking neighbours to see if they are blocked
                    if (currentEvaluatingNode.isBlocked == false)
                    {
                        //ignore starting nodes because they should already be closed
                        if (currentEvaluatingNode.gridPos != startingNode.gridPos)
                        {
                            //not sure how to ignore already existing nodes because they are duplicating in the open list
                            Open.Remove(startingNode);
                            Open.Add(currentEvaluatingNode);
                        }
                    }
                    else
                    {
                        Open.Remove(currentEvaluatingNode);
                        Closed.Add(currentEvaluatingNode);
                    }
                }
            }
            Closed.Add(startingNode);
            startingNode = Open[Random.Range(0, Open.Count)];
        }

        //for visual purposes & debugging
        public void OnDrawGizmos()
        {
            //with foreach loops the data in the container can be labeled anything
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
            
            foreach (Node i in Closed)
            {
                if (i.isBlocked)
                {
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawWireCube(i.gridPos, Vector3.one);
                }

                else
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawWireCube(i.gridPos, Vector3.one);
                }
            }
            
        }
    }
}
