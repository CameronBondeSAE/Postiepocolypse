using Anthill.AI;
using UnityEngine;


namespace Damien
{
    public class BlindTarget : AntAIState
    {
        public GameObject owner;


        //Reset states function call
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
        }

        public override void Enter()
        {
            base.Enter();
            owner.GetComponent<Blinder>().RpcFlashPlay();
            Finish();
        }
    }
}