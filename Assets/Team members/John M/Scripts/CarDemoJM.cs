using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarDemoJM : MonoBehaviour
{
    private Rigidbody rb;

    public Vector3 carSpeed;
    public Vector3 turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputSystem.GetDevice<Keyboard>().wKey.isPressed)
        {
            rb.AddRelativeForce(carSpeed);
        }

        if (InputSystem.GetDevice<Keyboard>().sKey.isPressed)
        {
                rb.AddRelativeForce(-carSpeed); 
        }

        if (InputSystem.GetDevice<Keyboard>().aKey.isPressed)
        {
                rb.AddRelativeTorque(-turnSpeed); 
        }

        if (InputSystem.GetDevice<Keyboard>().dKey.isPressed)
        {
                rb.AddRelativeTorque(turnSpeed); 
        }
        
    }
}
    
