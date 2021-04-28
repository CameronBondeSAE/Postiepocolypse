using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimPearson
{
    
public class Energy : MonoBehaviour
{
    public float MinAmount = 0f;
    public float CurrentAmount;
    public float MaxAmount = 20f;
    //public bool isUsing = false;
    public float Drain = 2f;
    public float MoveDrainScale;
    public float StandingDrain = 1f;
    public float Regen = 0f;
    private Vector3 currentPos;
    private Vector3 lastPos;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
        lastPos = currentPos;
        if (GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        }
        else
        {
            if (GetComponentInParent<Rigidbody>() != null)
            {
                rb = GetComponentInParent<Rigidbody>();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        currentPos = transform.position;

        float speed = (lastPos - currentPos).magnitude;

        float distance = Vector3.Distance(currentPos, lastPos);
        if (distance > 0.2f)
        {
            Drain = speed * MoveDrainScale;
            Regen = 0f;
        }
        else
        {
            Drain = StandingDrain;
            //Regen = Drain *2;
        }
        //if(isUsing == true)
        if(CurrentAmount >= MinAmount)
        {
            CurrentAmount -= Drain * Time.deltaTime;
            // Reduce energy by the Drain value per second
            if (CurrentAmount < MinAmount)
            {
                CurrentAmount = MinAmount;
                Regen = Drain *2;
            }
            
        }
        if (CurrentAmount <= MaxAmount)
        {
            CurrentAmount += Regen * Time.deltaTime;
            if (CurrentAmount > MaxAmount)
            {
                CurrentAmount = MaxAmount;
                Regen = 0f;
            }
            
        }
        lastPos = currentPos;
    }
}
}

