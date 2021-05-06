using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;
using ZachFrench;


namespace Damien
{
    public class EntityIdle : AntAIState
    {
        public GameObject owner;
        public Vector3 scale = Vector3.one;
        public float   timeScale = 1f;
        Vector3 startingPosition;
        private int targetViewRadius = 30;
        private Blinder _blinder;
        private NavMeshAgent _navMeshAgent;
        private PatrolManager _patrolManager;
        

        
        public override void Create(GameObject aGameObject)
        {
            startingPosition = transform.position;
            base.Create(aGameObject);
            owner = aGameObject;
            _blinder = owner.GetComponent<Blinder>();
            _navMeshAgent = owner.GetComponent<NavMeshAgent>();
            _patrolManager = FindObjectOfType<PatrolManager>();
        }

       

        public override void Enter()
        {
            base.Enter();
            owner.GetComponentInParent<FOV>().targets = LayerMask.GetMask("Player");
            owner.GetComponentInParent<FOV>().viewRadius = targetViewRadius;
              
            //AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
            //antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            //antAIAgent.worldState.Set("Target in View Range", false);
            //antAIAgent.worldState.EndUpdate();

            

            if (owner.GetComponent<FOV>().listOfTargets.Count != 0)
            {
                Finish();
            }
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            
            _blinder.Idle();

            if (_navMeshAgent.remainingDistance < 1f)
            {
                _navMeshAgent.SetDestination(_patrolManager.paths[Random.Range(0, _patrolManager.paths.Count)].transform
                    .position);
            }

            if (owner.GetComponent<FOV>().listOfTargets.Count != 0)
            {
                AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("Target in View Range", true);
                antAIAgent.worldState.EndUpdate();
                Finish();
            }
        }
    }
}