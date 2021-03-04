using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZachFrench
{
    public class Smell : MonoBehaviour
    {
        //Level 1 
        //Creation of Sphere of influence using a trigger field
        //Uses SphereCollider

        private SphereCollider smellRadius;
        public float radius;
        

        private void Awake()
        {
            smellRadius = gameObject.AddComponent<SphereCollider>();
            smellRadius.isTrigger = true;
            radius = 5;
        }
        

        // Update is called once per frame
        void Update()
        {
            smellRadius.radius = radius;
        }


        private void OnTriggerEnter(Collider other)
        {
            Nose nose = other.GetComponent<Nose>();
            if (nose)
            {
                nose.Smelling(other.transform.position);
            }
        }
    }
}
