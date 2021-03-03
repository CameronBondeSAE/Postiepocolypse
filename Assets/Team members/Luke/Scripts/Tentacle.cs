using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;
using UnityEngine.UIElements;
using SplineNode = TreeEditor.SplineNode;

namespace Luke
{
    public class Tentacle : MonoBehaviour
    {
        public Spline spline;
        public Transform targetPosition;
        
        public float perlinX;
        public float perlinY;
        public float perlinZ;
        
        private SplineMesh.SplineNode currentSplineNode;

        // Start is called before the first frame update
        void Start()
        {
            TentacleMove();

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TentacleMove()
        {
            Vector3 targetDir = targetPosition.position;

            for (int i = 0; i < spline.Length; i++)
            {

                //this is not right
                Vector3 perlinPosX = new Vector3(perlinX, 0);
                Vector3 perlinPosY = new Vector3(0, perlinY);
                Vector3 perlinPosZ = new Vector3(0, 0, perlinZ);
                
                currentSplineNode = spline.nodes[i];
                //this will need changing too
                currentSplineNode.Position = Mathf.PerlinNoise(perlinPosX.x,perlinPosY.y) * perlinPosZ;
                
                currentSplineNode.Direction = targetDir;
                spline.nodes.Add(currentSplineNode);
                
            }
        }
    }
}
