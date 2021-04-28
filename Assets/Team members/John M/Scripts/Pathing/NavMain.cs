using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

public class NavMain : MonoBehaviour
{
    private AntAIAgent _antAIAgent;
    public PatrolPoint currentTarget;
    

    private void Awake()
    {
        _antAIAgent = GetComponent<AntAIAgent>();
    }

    void Start()
    {
        _antAIAgent.SetGoal("Deposit Item");
    }

    // Update is called once per frame
    private void Update()
    {
      
    }
}
