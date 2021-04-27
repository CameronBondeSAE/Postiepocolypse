using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class CollectEnergy : AntAIState
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
            
            Finish();
        }
    }
}