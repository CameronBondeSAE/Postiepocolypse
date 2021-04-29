using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using JonathonMiles;
using UnityEngine;

public class NavMain : MonoBehaviour
{
    private AntAIAgent _antAIAgent;
    public PatrolPoint currentTarget;
    public FOV itemFov;
    public FOV playerFOV;
    public Transform itemTarget;
    public Transform playerTarget;
    

    private void Awake()
    {
        _antAIAgent = GetComponent<AntAIAgent>();
    }

    void Start()
    {
        _antAIAgent.SetGoal("Arrived at Target");
    }

    // Update is called once per frame
    private void Update()
    {
      SearchFOV();
    }

    void SearchFOV()
    {
        if (itemFov.listOfTargets.Count != null)
        {
            if (itemFov.listOfTargets.Count > 0)
            {
                foreach (GameObject item in itemFov.listOfTargets)
                {
                    Debug.Log("Item has been found");
                    itemTarget = item.transform;
                    currentTarget = null;

                }
            }
        }
        
    }
}
