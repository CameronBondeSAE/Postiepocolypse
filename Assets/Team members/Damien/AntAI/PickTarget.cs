using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class PickTarget : AntAIState
    {
        public GameObject entity;

        public override void Enter()
        {
            base.Enter();

            FakeTarget[] fakeTargets = FindObjectsOfType<FakeTarget>();
            FakeTarget fakeTarget = fakeTargets[Random.Range(0, fakeTargets.Length - 1)];

            if (fakeTarget == null)
            {

            }

            Finish();
        }

    }
}