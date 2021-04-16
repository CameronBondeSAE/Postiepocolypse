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
    public float Drain;
    public float Regen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(isUsing == true)
        if(CurrentAmount >= MinAmount)
        {
            CurrentAmount -= Drain * Time.deltaTime;
            // Reduce energy by the Drain value per second
            if (CurrentAmount == MinAmount -1)
            {
                CurrentAmount = 0f;
            }
            
        }
        if (CurrentAmount <= MaxAmount)
        {
            CurrentAmount += Regen * Time.deltaTime;
            if (CurrentAmount == MaxAmount + 1)
            {
                CurrentAmount = 20f;
            }
            
        }
    }
}
}

