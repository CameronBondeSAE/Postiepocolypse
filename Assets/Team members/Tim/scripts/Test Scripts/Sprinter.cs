using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TimPearson
{
    public class Sprinter : MonoBehaviour
{
    
    public float Speed;
    public bool isBoosting = false;
    public Rigidbody rb;
    public float Boost;
    public Energy energy;
    public float decreaseSpeed;

   
    // Start is called before the first frame update
    void Start()
    {
        energy = GetComponent<Energy>();
        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mi = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Speed = (mi.normalized * Boost).magnitude;
        rb.AddRelativeForce(Speed,0,0);

        
        if(isBoosting == true)
        {
            // Reduce energy by decreaseSpeed per second
            energy.Amount -= decreaseSpeed * Time.deltaTime;
            

            // double the move distance
            Boost *= 10f;
            Boost = Mathf.Clamp(Boost, 0, 50f);
        }

        if (isBoosting == false)
        {
            //energy.Amount += decreaseSpeed * Time.deltaTime;
            Boost = 10f;
        }
    }
   
}
}