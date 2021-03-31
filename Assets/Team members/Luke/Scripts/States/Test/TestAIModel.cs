using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class TestAIModel : MonoBehaviour
    {

        public AntAIAgent antAIAgent;
        public Target target;
        
        // Start is called before the first frame update
        void Start()
        {
            antAIAgent.SetGoal("At Position");
        }
    }
}
