using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using UnityEngine;

namespace Damien
{
    public class Blinder : MonoBehaviour
    {
        public AntAIAgent antAIAgent;
        public Target target;
        
        // Start is called before the first frame update
        void Start()
        {
            antAIAgent.SetGoal("Arrive at target");
        }
    }
}
