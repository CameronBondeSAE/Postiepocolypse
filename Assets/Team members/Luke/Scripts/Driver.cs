using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float reverseSpeed;
    public float torque;
    public Vector3 localVelocity;
    public float rayLength;
    public LayerMask layer;
    public float maxSpringForce;
    public float springResistance;
    public Transform[] Wheels;
    
    void Update()
    {
        //to keep off the ground 
        RaycastOut();

        //to get the current relative force and apply it to the x axis
        localVelocity = transform.InverseTransformDirection(rb.velocity);
        rb.AddRelativeForce(-localVelocity.x,0,0);

        if (InputSystem.GetDevice<Keyboard>().wKey.isPressed)
        {
            rb.AddRelativeForce(0,0,speed);
        }
        
        if (InputSystem.GetDevice<Keyboard>().sKey.isPressed)
        {
            rb.AddRelativeForce(0,0,-reverseSpeed);
        }

        if (InputSystem.GetDevice<Keyboard>().aKey.isPressed)
        {
            rb.AddRelativeTorque(0,-torque,0);
        }
        
        if (InputSystem.GetDevice<Keyboard>().dKey.isPressed)
        {
            rb.AddRelativeTorque(0,torque,0);
        }
    }

    public void RaycastOut()
    {
        //ray stuff
        foreach (Transform wheel in Wheels)
        {
            Ray ray = new Ray();
            ray.origin = wheel.transform.position;
            ray.direction = -wheel.transform.up;
            RaycastHit raycastHit = new RaycastHit();
            
            Debug.DrawRay(wheel.transform.position,-wheel.transform.up,Color.yellow);
            
            if (Physics.Raycast(ray, out raycastHit, rayLength, layer))
            {
                //apply spring resistance here
                float force = springResistance - rayLength;
                force *= maxSpringForce;

                rb.AddForceAtPosition(transform.up * force, wheel.transform.position);
            }
        }

        
    }
}
