using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Luke
{
    public class WiggleFly : MonoBehaviour
    {
        public Rigidbody rb;
        public float speed;
        public float reverseSpeed;
        public float torque;
        public Vector3 localVelocity;

        // Update is called once per frame
        void Update()
        {
            localVelocity = transform.InverseTransformDirection(rb.velocity);

            if (InputSystem.GetDevice<Keyboard>().wKey.isPressed)
            {
                rb.AddRelativeForce(0, 0, speed);
            }

            if (InputSystem.GetDevice<Keyboard>().sKey.isPressed)
            {
                rb.AddRelativeForce(0, 0, -reverseSpeed);
            }

            if (InputSystem.GetDevice<Keyboard>().aKey.isPressed)
            {
                rb.AddRelativeTorque(0, -torque, 0);
                rb.AddRelativeForce(0, -localVelocity.x, 0);
            }

            if (InputSystem.GetDevice<Keyboard>().dKey.isPressed)
            {
                rb.AddRelativeTorque(0, torque, 0);
                rb.AddRelativeForce(0, localVelocity.x, 0);

            }
        }
    }
}