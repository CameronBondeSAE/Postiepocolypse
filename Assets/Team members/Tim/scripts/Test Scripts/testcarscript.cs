using System;
using System.Collections;
using System.Collections.Generic;
using TimPearson;
using UnityEngine;
using UnityEngine.InputSystem;

public class testcarscript : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed;
    public float Turn;
    public Vector3 localVelocity;
    private Sprint sprint;
    public float Boost;
    
    
    // Start is called before the first frame update
    void Start()
    {
        sprint = GetComponent<Sprint>();
    }

    // Update is called once per frame
    void Update()
    {
        localVelocity = transform.InverseTransformDirection(rb.velocity);
        rb.AddRelativeForce(-localVelocity.x,0,0);
        if (InputSystem.GetDevice<Keyboard>().wKey.isPressed)
        {
            rb.AddRelativeForce(Speed,0,0);
        }
        if (InputSystem.GetDevice<Keyboard>().sKey.isPressed)
        {
            rb.AddRelativeForce(-Speed,0,0);
        }
        if (InputSystem.GetDevice<Keyboard>().aKey.isPressed)
        {
            rb.AddRelativeTorque(0,Turn,0);
        }
        if (InputSystem.GetDevice<Keyboard>().dKey.isPressed)
        {
            rb.AddRelativeTorque(0,-Turn,0);
        }
        if(InputSystem.GetDevice<Keyboard>().rightCtrlKey.wasPressedThisFrame && sprint.energy.CurrentAmount > 0)
        {
            sprint.isBoosting = true;
        }

        if (InputSystem.GetDevice<Keyboard>().rightCtrlKey.wasReleasedThisFrame)
        {
            sprint.isBoosting = false;
        }
    }
}
