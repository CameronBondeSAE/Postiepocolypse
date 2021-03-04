using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZachFrench
{

    public class Node
    {
        public bool isBlocked;
    }
    
    

    public class WorldScanner : MonoBehaviour
    {
        private int gridSizeX = 50;
        private int gridSizeZ = 50;
        
        
        private Node[,] grid;
        
        
        
        // Start is called before the first frame update
        void Start()
        {
            grid = new Node[gridSizeX,gridSizeZ];
        }

        // Update is called once per frame
        void Update()
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    grid[x, z] = new Node();
                    grid[x, z].isBlocked = false;
                    if (Physics.CheckBox(new Vector3(x , 0, z ),
                        new Vector3(1,1,1)))
                    {
                        grid[x, z].isBlocked = true;
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    if (grid[x,z] != null)
                    {
                        if (grid[x,z].isBlocked)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawWireCube(new Vector3(x,0,z),Vector3.one);
                        }
                    }
                }
            }
        }
    }
}