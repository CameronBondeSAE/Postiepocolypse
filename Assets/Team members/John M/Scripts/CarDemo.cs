using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace JonathonMiles
    {

        public class CarDemo : MonoBehaviour
        {
            private Rigidbody rb;

            public Vector3 carSpeed;
            public Vector3 turnSpeed;
            public Vector3 localVelocity;
            
            void Start()
            {
                rb = GetComponent<Rigidbody>();
            }

            private void Update()
            {
                Driving();
            }

            // Update is called once per frame
            public void Driving()
            {
                //forward movement
                 if (InputSystem.GetDevice<Keyboard>().wKey.isPressed)
                 {
                            rb.AddRelativeForce(carSpeed);
                 }
                //reverse / braking
                 if (InputSystem.GetDevice<Keyboard>().sKey.isPressed)
                 {
                            rb.AddRelativeForce(-carSpeed);
                 }
                //turning inputs
                 if (InputSystem.GetDevice<Keyboard>().aKey.isPressed)
                 {
                            rb.AddRelativeTorque(-turnSpeed);
                 }

                 if (InputSystem.GetDevice<Keyboard>().dKey.isPressed)
                 {
                            rb.AddRelativeTorque(turnSpeed);

                 }
            }
        }
    }

    

    
