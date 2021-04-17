using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class Blinder : MonoBehaviour
    {
        public GameObject owner;
        public AntAIAgent antAIAgent;
        public GameObject target;
        
        // Start is called before the first frame update
        void Start()
        {
            antAIAgent.SetGoal("Arrive at target");
        }
    }
}
