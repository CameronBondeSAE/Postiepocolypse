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
    private Sprinter sprint;
    public float Boost;
    
    
    // Start is called before the first frame update
    void Start()
    {
        sprint = GetComponent<Sprinter>();
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
        if(InputSystem.GetDevice<Keyboard>().rightCtrlKey.wasPressedThisFrame && sprint.energy.Amount > 0)
        {
            
            sprint.isBoosting = true;
        }

        if (InputSystem.GetDevice<Keyboard>().rightCtrlKey.wasReleasedThisFrame)
        {
            sprint.isBoosting = false;
        }
        
        
        //  Vector2 mi = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // Speed = (mi.normalized * Boost).magnitude;
        //
        // if(InputSystem.GetDevice<Keyboard>().rightCtrlKey.wasPressedThisFrame && energy > 0)
        // {
        //     
        //     isBoosting = true;
        //
        //     // if needed avoid negative value
        //     energy = Mathf.Max(0, energy);
        //
        //     // double the move distance
        //     Boost *= 10f;
        // }
        //
        // if (InputSystem.GetDevice<Keyboard>().rightCtrlKey.wasReleasedThisFrame)
        // {
        //     Boost = 10f;
        //     isBoosting = false;
        // }
        // if(isBoosting == true)
        // {
        //     // Reduce energy by decreaseSpeed per second
        //     energy -= decreaseSpeed * Time.deltaTime;
        // }
        //
        // if (isBoosting == false)
        // {
        //     energy += decreaseSpeed * Time.deltaTime;
        // }
    }
}
