using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class PickTarget : AntAIState
    {
        public GameObject blinder;

        public override void Enter()
        {
            base.Enter();

            Target[] targets = FindObjectsOfType<Target>();
            Target target = targets[Random.Range(0, targets.Length - 1)];

            if (target == null)
            {

            }

            Finish();
        }

    }
}