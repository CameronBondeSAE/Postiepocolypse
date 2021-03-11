using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ZachFrench
{


    public class AStarPathfinding : MonoBehaviour
    {

        public WorldScanner worldScanner;

        //Creating two lists that hold the nodes for open and closed
        public List<Node> Open;

        public List<Node> Closed;

        //public Vector2 currentPosition;
        public Node currentNode;

        public Vector2 currentPosition;


        private void Start()
        {
            //currentPosition = Vector2.zero;
            Node position = currentNode;
            if (position != null && Open != null)
            {
                currentNode = worldScanner.grid[(int) currentPosition.x, (int) currentPosition.y];
            }
        }
        
        
        // Update is called once per frame
        void Update()
        {
            Open.Add(currentNode);
            Open.Remove(currentNode);
            Closed.Add(currentNode);


            for (int neighbourX = -1 + (int)currentPosition.x; neighbourX < 2; neighbourX++)
            {
                Debug.Log("PositionCheck:" + currentPosition);
                for (int neighbourY = -1; neighbourY < 2; neighbourY++)
                {
                    Debug.Log("PositionCheck:" + currentPosition);
                    
                    
                    /*Open.Add(worldScanner.grid[neighbourX,neighbourY]);
                    if (worldScanner.grid[neighbourX, neighbourY] != null)
                    {
                            
                    }*/
                }
            }
        }
    }
}