using System;
using RileyMcGowan;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RileyMcGowan
{
    public class AStarPathing : MonoBehaviour
    {
        public WorldScanner worldScanner;
        public List<Node> Open;
        public List<Node> Closed;
        public Node currentNode;
        public Node workingNode;
        public Vector2 currentPosition;
        
        void Start()
        {
            Open.Add(worldScanner.gridList[Random.Range(0, worldScanner.gridSize.x), Random.Range(0, worldScanner.gridSize.z)]);
        }
        
        void Update()
        {
            currentNode = Open[Random.Range(0, Open.Count)];
            Open.Remove(currentNode);
            Closed.Add(currentNode);

            for (int x = -1; x < 2; x++)
            {
                for (int z = -1; z < 2; z++)
                {
                    workingNode = worldScanner.gridList[currentNode.nodePos.x + x, currentNode.nodePos.y + z]; //Used for working with the current node without rewriting
                    if (workingNode != null && Closed.Contains(workingNode) != true && Open.Contains(workingNode))
                    {
                        Open.Add(workingNode);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            //Gizmos.DrawCube();
        }
    }
}