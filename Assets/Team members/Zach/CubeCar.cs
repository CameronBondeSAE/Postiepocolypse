using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeCar : MonoBehaviour
{
    public Rigidbody Rigidbody;

    public float XSpeed;

    public float YSpeed;

    public Vector3 localVelocity;

    public float friction = 1; 
    
    // Start is called before the first frame update
    void Start()
    {
        XSpeed = 1;
        YSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {

        localVelocity = transform.InverseTransformDirection(Rigidbody.velocity);
        Rigidbody.AddRelativeForce(-localVelocity.x * friction,0,0);
            
        //Front and Back Driving
        if (InputSystem.GetDevice<Keyboard>().wKey.isPressed)
        {
            Rigidbody.AddRelativeForce(0,0,XSpeed);
        }
        if (InputSystem.GetDevice<Keyboard>().sKey.isPressed)
        {
            Rigidbody.AddRelativeForce(0,0,-XSpeed);
        }
        
        //Left and Right turning 
        if (InputSystem.GetDevice<Keyboard>().wKey.isPressed || InputSystem.GetDevice<Keyboard>().sKey.isPressed)
        {
            if (InputSystem.GetDevice<Keyboard>().aKey.isPressed)
            {
                Rigidbody.AddRelativeTorque(0,-YSpeed,0);
            }
            if (InputSystem.GetDevice<Keyboard>().dKey.isPressed)
            {
                Rigidbody.AddRelativeTorque(0,YSpeed,0);
            } 
        }
    }
}
