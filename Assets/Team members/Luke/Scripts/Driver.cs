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

    void Update()
    {
        //to keep off the ground 
        Debug.DrawRay(transform.position,Vector3.down,Color.green);
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
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = Vector3.down;
        RaycastHit raycastHit = new RaycastHit();

        if (Physics.Raycast(ray, out raycastHit, rayLength, layer))
        {
            //apply spring resistance here
            Debug.Log("push back");
            float force = 1 - rayLength;
            force *= maxSpringForce;
        }
    }
}
