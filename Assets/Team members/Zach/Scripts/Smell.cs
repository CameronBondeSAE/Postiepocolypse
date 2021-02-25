using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class Smell : MonoBehaviour
    {
        //Level 1 
        //Creation of Sphere of influence using a trigger field
        //Uses SphereCollider

        private SphereCollider smellRadius;
        public float radius = 1;
        

        private void Awake()
        {
            smellRadius = gameObject.AddComponent<SphereCollider>();
        }


        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            smellRadius.radius = radius;
        }
    }
}
