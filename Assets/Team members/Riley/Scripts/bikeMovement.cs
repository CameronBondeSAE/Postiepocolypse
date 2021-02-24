using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class bikeMovement : MonoBehaviour
{
    public Rigidbody rb;
    private float turnSpeed;
    public float carSpeed;
    private float drift;
    public int maxSpeed;
    public Vector3 localVelocity;
    public float springHeight;
    public float maxSpringHeight;
    private float force;
    public int rayLength;
    
    //raycast
    private float distanceToGround;
    private Ray raycast;
    private RaycastHit raycastToGround;
    public float redRayDistance;
    
    void Start()
    {
        drift = 0.1f;        
    }
    
    void Update()
    {
        //Raycast
        raycast = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(raycast, out raycastToGround, rayLength))
        {
            force = springHeight - rayLength;
            force *= maxSpringHeight;
            rb.AddRelativeForce(0, force, 0);
        }
        
        distanceToGround = raycastToGround.distance;
        
        //Variables
        localVelocity = transform.InverseTransformDirection(rb.velocity);
        turnSpeed = localVelocity.z*15f;
        rb.AddRelativeForce(-localVelocity.x, 0,0);
        
        //Inputs
        if (localVelocity.z < maxSpeed)
        {
            if (InputSystem.GetDevice<Keyboard>().wKey.isPressed)
            {
                rb.AddRelativeForce(0,0,carSpeed);
            }
            if (InputSystem.GetDevice<Keyboard>().sKey.isPressed)
            {
                rb.AddRelativeForce(0,0,-carSpeed);
            }
        }
        if (InputSystem.GetDevice<Keyboard>().aKey.isPressed)
        {
            rb.AddRelativeTorque(0,-turnSpeed,0);
        }
        if (InputSystem.GetDevice<Keyboard>().dKey.isPressed)
        {
            rb.AddRelativeTorque(0,turnSpeed,0);
        }
    }
}
