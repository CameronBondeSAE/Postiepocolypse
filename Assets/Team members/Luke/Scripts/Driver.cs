using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Luke
{
    public class Driver : MonoBehaviour
    {
        public Rigidbody rb;
        public float speed;
        public float reverseSpeed;
        public Vector3 localVelocity;
        public float springRayLength;
        public float maxSpringForce;
        public CurveField springForceCurve;
        public float springResistance;
        public float wheelFriction;
        public float steering;
        public float steeringAngle;
        public Transform[] wheels;
        public Transform[] steeringWheels;

        void Update()
        {
            CarMovement();
            Springs();
        }

        public void CarMovement()
        {
            foreach (Transform wheel in wheels)
            {
                Vector3 wheelPos = wheel.transform.position;
                
                //getting the local velocity to apply it as a lateral friction
                localVelocity = wheel.transform.InverseTransformDirection(rb.velocity);
                rb.AddRelativeForce(-localVelocity.x,0,0);

                //Acceleration
                if (InputSystem.GetDevice<Keyboard>().wKey.isPressed)
                {
                    rb.AddForceAtPosition(wheel.transform.InverseTransformDirection(wheel.transform.forward) * speed,
                        wheelPos);

                    //wheel friction
                    rb.AddForceAtPosition(localVelocity * -wheelFriction,
                        wheelPos);
                }

                //Reverse
                if (InputSystem.GetDevice<Keyboard>().sKey.isPressed)
                {
                    rb.AddForceAtPosition(wheel.transform.InverseTransformDirection(-wheel.transform.forward) * reverseSpeed,
                        wheelPos);

                    //wheel friction
                    rb.AddForceAtPosition(localVelocity * wheelFriction,
                        wheelPos);
                }

                //Steering left
                if (InputSystem.GetDevice<Keyboard>().aKey.isPressed)
                {
                    //steering front wheels
                    foreach (Transform steeringWheel in steeringWheels)
                    {
                        steeringWheel.transform.localRotation = Quaternion.Euler(0,-steeringAngle,0);
                    }
                }

                //Steering right
                if (InputSystem.GetDevice<Keyboard>().dKey.isPressed)
                {
                    //steering front wheels
                    foreach (Transform steeringWheel in steeringWheels)
                    {
                        steeringWheel.transform.localRotation = Quaternion.Euler(0,steeringAngle,0);
                    }
                }
            }
        }


        //raycast system on wheels and Spring functionality
        public void Springs()
        {
            foreach (Transform wheel in wheels)
            {
                //ray stuff
                RaycastHit hitInfo = new RaycastHit();

                //not sure how to get a curve of the spring strength going
                float springDistance = Vector3.Distance(wheel.transform.position, hitInfo.point);
                float force = springResistance - springDistance;
                force *= maxSpringForce;

                //this is where the spring happens
                //255 in the layer means everything
                if (Physics.Raycast(wheel.transform.position,-wheel.transform.up, out hitInfo,springRayLength , 255))
                {
                    Debug.DrawLine(wheel.transform.position,hitInfo.point,Color.yellow);
                    rb.AddForceAtPosition(transform.InverseTransformDirection(wheel.transform.up) * force,
                        wheel.transform.position);
                }
            }
        }
    }
}
