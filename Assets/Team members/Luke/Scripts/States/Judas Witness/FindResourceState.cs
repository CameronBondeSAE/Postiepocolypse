using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class FindResourceState : AntAIState
    {
        public GameObject owner;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("find resource state");

            // HACK
            var targets = FindObjectsOfType<JudasTarget>();

            // Pick a random target
            if (targets != null)
            {
                var judasTargetPos = targets[Random.Range(0, targets.Length)];
                owner.GetComponent<JudasWitnessModel>().judasTarget = judasTargetPos;
            }

            Finish();
        }
    }
}