using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Luke
{
    public class JudasWitness : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        public Transform target;
        
        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.SetDestination(target.position);
        }
    }
}
