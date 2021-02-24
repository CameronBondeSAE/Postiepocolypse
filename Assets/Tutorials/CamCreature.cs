using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CamCreature : MonoBehaviour
{
	public NavMeshAgent navMeshAgent;
	public Transform    target;

    // Start is called before the first frame update
    void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.SetDestination(target.position);
	}
}
