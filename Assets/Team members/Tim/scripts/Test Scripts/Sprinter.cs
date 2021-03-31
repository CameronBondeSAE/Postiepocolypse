using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Anthill.AI;

namespace TimPearson
{
    public class Sprinter : MonoBehaviour
{
    public float Speed;
    private bool isBoosting = false;
    public Rigidbody rb;
    public float Boost;
    
    public Energy amount;
    public float decreaseSpeed;

    public Target target;
   public AntAIAgent antAIAgent;
    // Start is called before the first frame update
    void Start()
    {
        amount = GetComponent<Energy>();
        rb = gameObject.GetComponent<Rigidbody>();
        antAIAgent.SetGoal("At Position");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mi = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Speed = (mi.normalized * Boost).magnitude;
        rb.AddRelativeForce(Speed,0,0);

        if(InputSystem.GetDevice<Keyboard>().rightCtrlKey.wasPressedThisFrame && amount.Amount > 0)
        {
            
            isBoosting = true;

            // if needed avoid negative value
            amount.Amount = Mathf.Max(0, amount.Amount);

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
            amount.Amount -= decreaseSpeed * Time.deltaTime;
        }

        if (isBoosting == false)
        {
            amount.Amount += decreaseSpeed * Time.deltaTime;
        }
    }
   
}
}