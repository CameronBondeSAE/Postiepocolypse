using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace TimPearson
{
    
    public class SprinterAI : MonoBehaviour
    {
        public Target target;
        public AntAIAgent antAIAgent;
            
        // Start is called before the first frame update
        void Start()
        {
            if (!(antAIAgent is null)) antAIAgent.SetGoal("At Position");
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }

}
