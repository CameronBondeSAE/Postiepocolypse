using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimPearson
{
    public class Sprint : MonoBehaviour
{
    public bool isBoosting = false;
    public Rigidbody rb;
    public float Boost;
    public Energy energy;
    public float Drain;

   
    // Start is called before the first frame update
    void Start()
    {
        energy = GetComponent<Energy>();
        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isBoosting == true)
        {
            // Reduce energy by the Drain amount per second
            energy.Amount -= Drain * Time.deltaTime;

            // double the move distance
            Boost = 50f;
            Boost = Mathf.Clamp(Boost, 0, 100f);
        }

        if (isBoosting == false)
        {
            Boost = 0f;
        }
        rb.AddRelativeForce(0,0,Boost);
    }
   
}
}