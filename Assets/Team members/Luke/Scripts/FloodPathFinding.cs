using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class FloodPathFinding : MonoBehaviour
    {
        public Node currentNode;
        public List<Node> Open;
        public List<Node> Closed;

        private WorldScanner worldScanner;
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

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
                    currentNode = new Node();
                    currentNode.gridPos = new Vector3Int(x,0,z);
                    Open.Add(currentNode);
                    
                    //not quite working
                    Node neighbourNode = new Node();
                    neighbourNode.gridPos = new Vector3Int(currentNode.gridPos.x + x,0,currentNode.gridPos.z + z);

                    if (neighbourNode.isBlocked && worldScanner.gridNodeRef != null)
                    {
                        Closed.Add(neighbourNode);
                    }
                    
                    Open.Add(neighbourNode);
                    
                    // foreach (Node neighbourNodes in Open)
                    // {
                    //     PathFlooding();
                    // }
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
                    //the open nodes
                    Gizmos.color = Color.blue;
                    Gizmos.DrawWireCube(new Vector3(x, 0, z),Vector3.one);
                    

                    if (currentNode.isBlocked && worldScanner.gridNodeRef != null)
                    {
                        Gizmos.color = Color.black;
                        Gizmos.DrawWireCube(new Vector3(x, 0, z),Vector3.one);
                    }

                    // foreach (Node neighbourNodes in Open)
                    // {
                    //     OnDrawGizmos();
                    // }
                }
            }
        }
    }
}
