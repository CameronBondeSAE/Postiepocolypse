using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

public class NavModel : MonoBehaviour
{
    public AntAIAgent antAIAgent;
    
    void Start()
    {
        antAIAgent.SetGoal("Arrive At Target");
    }
    
    void Update()
    {
        
    }
}
