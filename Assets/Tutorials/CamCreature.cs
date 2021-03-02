using UnityEngine;
using UnityEngine.AI;

namespace CameronBonde
{
	public class CamCreature : CreatureBase
	{
		public NavMeshAgent navMeshAgent;
		public Transform    target;

		// public Health health;

		public static float energy;

		// Start is called before the first frame update
		void Start()
		{
			navMeshAgent = GetComponent<NavMeshAgent>();
			navMeshAgent.SetDestination(target.position);
		}

		void Update()
		{
			Debug.Log(FakeManagerUsingStatic.numberOfCreatures);
			FakeManagerUsingStatic.KillEverything();

			Debug.Log(FakeManagerUsingSingleton.Instance.numberOfCreatures);
			FakeManagerUsingSingleton.Instance.KillEverything();
		}
	}
}