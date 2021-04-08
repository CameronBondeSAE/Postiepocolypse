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
        void Start()
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
                    grid[x, z].isBlocked = false;
                    if (Physics.CheckBox(new Vector3(x , 0, z ),
                        new Vector3(1,1,1)))
                    {
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