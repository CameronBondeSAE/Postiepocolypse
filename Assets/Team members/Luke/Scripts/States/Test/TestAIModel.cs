using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class TestAIModel : MonoBehaviour
    {

        public AntAIAgent antAIAgent;
        public JudasTarget judasTarget;
        
        // Start is called before the first frame update
        void Start()
        {
            antAIAgent.SetGoal("At Position");
        }
    }
}
