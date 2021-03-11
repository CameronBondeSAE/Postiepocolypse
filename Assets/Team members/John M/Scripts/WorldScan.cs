using UnityEngine;

namespace JonathonMiles
{
    public class Node
    {
        public bool isBlocked;
        public Vector3Int gridPos;
    }
    public class WorldScan : MonoBehaviour
    {
        public Node[,] grid; 
        public Vector3Int gridSize;
        void Awake()
        {
            grid = new Node[gridSize.x,gridSize.z];
        }
        void Update()
        {
            Scanning();
        }

        void Scanning()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int z = 0; z < gridSize.z; z++)
                {
                    grid[x, z] = new Node();
                    grid[x, z].gridPos = new Vector3Int(x,0,z);
                    
                    if (Physics.CheckBox(new Vector3(x , 0, z ),Vector3.one))
                    {
                        //doing a physics check along the grid to see if something 
                        //is in the way, checking for barriers along the path
                        grid[x, z].isBlocked = true;
                    }
                }
            }
        }
       void OnDrawGizmos()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int z = 0; z < gridSize.z; z++)
                {
                    if (Physics.CheckBox(new Vector3(x, 0, z),Vector3.one, Quaternion.identity))
                    {
                        //draw a red 1x1 cube at the center of the grid position when marked blocked
                        Gizmos.color = Color.red;
                        Gizmos.DrawWireCube(new Vector3(x, 0, z), Vector3.one);
                    }
                    else
                    {
                        //draw a green 1x1 cube at the grid position when marked not blocked
                        Gizmos.color = Color.green;
                        Gizmos.DrawWireCube(new Vector3(x , 0, z ), Vector3.one);
                    }
                     
                }
            }
        }

    }
}