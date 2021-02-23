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
        public AnimationCurve springForceCurve;
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

        ///TODO: Movement isn't quite working yet??
        public void CarMovement()
        {
            foreach (Transform wheel in wheels)
            {
                Vector3 wheelPos = transform.InverseTransformPoint(wheel.transform.position);
                
                //getting the world velocity of wheel to apply it as a lateral friction
                localVelocity = rb.GetPointVelocity(wheel.transform.TransformPoint(wheelPos));
                
                //wheel friction
                rb.AddForceAtPosition(wheel.transform.InverseTransformDirection(-localVelocity.x,0,0) * wheelFriction,
                    transform.TransformPoint(wheelPos));

                //Acceleration
                if (InputSystem.GetDevice<Keyboard>().wKey.isPressed)
                {
                    rb.AddForceAtPosition(wheel.transform.InverseTransformDirection(wheel.transform.forward) * speed,
                        transform.TransformPoint(wheelPos));
                }

                //Reverse
                if (InputSystem.GetDevice<Keyboard>().sKey.isPressed)
                {
                    rb.AddForceAtPosition(wheel.transform.InverseTransformDirection(-wheel.transform.forward) * reverseSpeed,
                        transform.TransformPoint(wheelPos));
                }

                ///TODO: need to add gradual turning of wheels
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
                
                /// TODO: I'm not sure if this is working or not???
                float springDistance = Vector3.Distance(transform.InverseTransformPoint(wheel.transform.position), hitInfo.point);
                float force = springResistance - springForceCurve.Evaluate(springDistance/springRayLength);

                //this is where the spring happens
                //255 in the layer means everything
                if (Physics.Raycast(wheel.transform.position,-wheel.transform.up, out hitInfo, springRayLength, 255))
                {
                    Debug.DrawLine(wheel.transform.position,hitInfo.point,Color.yellow);
                    rb.AddForceAtPosition(transform.InverseTransformDirection(wheel.transform.up) * force,
                        wheel.transform.position);
                }
            }
        }
    }
}
