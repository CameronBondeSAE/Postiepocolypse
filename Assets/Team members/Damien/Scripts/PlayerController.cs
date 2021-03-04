using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damien
{
    public class PlayerController : MonoBehaviour
    {

        public CharacterController controller;

        public float movementSpeed = 3f;

        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * (movementSpeed * Time.deltaTime));
        }
    }
}
