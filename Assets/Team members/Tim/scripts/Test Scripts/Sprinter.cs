using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Sprinter : MonoBehaviour
{
    public float Speed;
    private bool isBoosting = false;
    
    public float Boost;
    [Range(0f,10f)]
    public float energy;
    public float decreaseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mi = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Speed = (mi.normalized * Boost).magnitude;

        if(InputSystem.GetDevice<Keyboard>().rightCtrlKey.wasPressedThisFrame && energy > 0)
        {
            
            isBoosting = true;

            // if needed avoid negative value
            energy = Mathf.Max(0, energy);

            // double the move distance
            Boost *= 10f;
        }

        if (InputSystem.GetDevice<Keyboard>().rightCtrlKey.wasReleasedThisFrame)
        {
            Boost = 10f;
            isBoosting = false;
        }
        if(isBoosting == true)
        {
            // Reduce energy by decreaseSpeed per second
            energy -= decreaseSpeed * Time.deltaTime;
        }

        if (isBoosting == false)
        {
            energy += decreaseSpeed * Time.deltaTime;
        }
    }
   
}
