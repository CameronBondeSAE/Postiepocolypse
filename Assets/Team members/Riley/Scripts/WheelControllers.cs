using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControllers : MonoBehaviour
{
    public Rigidbody rb;
    private float force;
    public float springHeight;
    public float maxSpringHeight;
    public Vector3 localVelocity;
    //raycast
    public int rayLength;
    private float distanceToGround;
    private Ray raycast;
    private RaycastHit raycastToGround;
    public float redRayDistance;
    void Start()
    {
        
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
        rb.AddRelativeForce(-localVelocity.x, 0,0);
    }
}
