using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;

namespace ZachFrench
{


    public class Wheel : MonoBehaviour
    {
        private Vector3 Origin;
        private Vector3 localVelocity;
        public float friction = 1;
        public float maxForce = 2;
        public float rayCastDistance = 10;
        public CubeCar parent;

        private void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            SpringForce();
        }

        void SpringForce()
        {
            //Raycast for the height of car/spring 
            Origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            localVelocity = transform.InverseTransformDirection(parent.Rigidbody.velocity);
            parent.Rigidbody.AddRelativeForce(-localVelocity.x * friction, 0, 0);

            RaycastHit hitinfo;
            hitinfo = new RaycastHit();
            Physics.Raycast(transform.position, -transform.up, out hitinfo, rayCastDistance, 255,
                QueryTriggerInteraction.Ignore);

            //draw line when something is hit
            if (hitinfo.collider)
            {
                Debug.DrawLine(transform.position, hitinfo.point, Color.green);
            }

            parent.Rigidbody.AddRelativeForce(0, maxForce - hitinfo.distance, 0);

        }
    }
}