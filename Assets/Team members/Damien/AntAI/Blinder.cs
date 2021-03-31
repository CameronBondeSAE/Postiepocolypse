using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using UnityEngine;

public class Blinder : MonoBehaviour
{
    public AntAIAgent AntAIAgent;

    public PickTarget target;
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
