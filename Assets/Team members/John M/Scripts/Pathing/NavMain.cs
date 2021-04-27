using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

public class NavMain : MonoBehaviour
{
    private AntAIAgent _antAIAgent;
    public WaterTarget currentTarget;
    public float safeDistance = 1f;
    private float directionToTarget;
    private Vector3 vectorToTarget;
    public bool invertDirection;
    private Vector3 vectorNormalised;
    private float signedToTarget;

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
