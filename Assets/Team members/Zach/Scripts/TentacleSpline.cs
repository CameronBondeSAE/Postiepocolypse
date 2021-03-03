using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;


namespace ZachFrench
{

    public class TentacleSpline : MonoBehaviour
    {

        public Spline spline;
        public float perlinX;
        public float perlinY;
        public float perlinZ;
        public Vector3 splinePosition;
        public Vector3 splineDirection;

        // Start is called before the first frame update
        void Start()
        {
            spline.nodes.Add(new SplineNode(splinePosition,splineDirection));
        }

        // Update is called once per frame
        void Update()
        {
            perlinX = Mathf.PerlinNoise(Random.Range(0f, 10f),Random.Range(0f, 10f));
            perlinY = Mathf.PerlinNoise(Random.Range(0f, 10f),Random.Range(0f, 10f));
            perlinZ = Mathf.PerlinNoise(Random.Range(0f, 10f),Random.Range(0f, 10f));
            splinePosition = new Vector3(perlinX,perlinY,perlinZ);
            splineDirection = new Vector3(perlinX,perlinY,perlinZ);
        }
    }
}
