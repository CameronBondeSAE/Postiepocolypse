using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

public class FakeEntityDamien : MonoBehaviour
{
    public AntAIAgent AntAIAgent;
    // Start is called before the first frame update
    void Start()
    {
        AntAIAgent.SetGoal("Arrive at Target");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
