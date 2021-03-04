using System;
using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;
using UnityEngine.UIElements;

namespace Luke
{
    public class Tentacle : MonoBehaviour
    {
        public Spline spline;
        public Transform targetPosition;
        
        public float perlinX;
        public float perlinY;
        public float perlinZ;
        
        private SplineNode currentSplineNode;

        // Start is called before the first frame update
        void Start()
        {
            TentacleMove();
        }

        public void TentacleMove()
        {
            Vector3 targetDir = targetPosition.position;

            

            for (int i = 0; i < spline.Length; i++)
            {
                currentSplineNode = spline.nodes[i];
            
                //this is probably not right
                Vector3 perlinPosX = new Vector3(perlinX, 0) + currentSplineNode.Position;
                Vector3 perlinPosY = new Vector3(0, perlinY) + currentSplineNode.Position;
                Vector3 perlinPosZ = new Vector3(0, 0, perlinZ) + currentSplineNode.Position;
                
                //I'm not sure how to do a 3d perlin?
                currentSplineNode.Position = Mathf.PerlinNoise(perlinPosX.x,perlinPosY.y) * perlinPosZ;
                
                currentSplineNode.Direction = targetDir;
                spline.nodes.Add(currentSplineNode);
                
            }
        }
    }
}
