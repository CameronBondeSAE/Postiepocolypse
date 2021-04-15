using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class FindResourceState : AntAIState
    {
        public GameObject owner;
        public JudasTarget judasTargetPos;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            judasTargetPos = GetComponent<JudasTarget>();
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("find resource state");

            // HACK
            JudasTarget[] targets = FindObjectsOfType<JudasTarget>();

            // Pick a random target
            if (targets != null)
            {
                if (judasTargetPos == null)
                {
                    return;
                }
                else
                {
                    judasTargetPos = targets[Random.Range(0, targets.Length)];

                    owner.GetComponent<JudasWitnessModel>().judasTarget = judasTargetPos;
                }
            }

            Finish();
        }
    }
}