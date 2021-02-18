using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class bikeMovement : MonoBehaviour
{
    public Rigidbody rb;
    private float turnSpeed;
    public float carSpeed;
    private float turningCircle;
    private float drift;
    public int maxSpeed;
    public Vector3 localVelocity;
    
    //raycast
    private float distanceToGround;
    private Ray raycast;
    private RaycastHit raycastToGround;
    public float redRayDistance;
    
    void Start()
    {
        turningCircle = 0.000001f;
        drift = 0.1f;
        
    }
    
    void Update()
    {
        //Raycast
        raycast = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(raycast, out raycastToGround, 1f))
        {
            Debug.DrawLine(raycast.origin, raycastToGround.point, Color.green);
        }
        else
        {
            Debug.DrawLine(raycast.origin, raycast.origin + raycast.direction * redRayDistance, Color.red);
        }
        distanceToGround = raycastToGround.distance;
        
        //Variables
        localVelocity = transform.InverseTransformDirection(rb.velocity);
        turnSpeed = localVelocity.z/7f;
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
