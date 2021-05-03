using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class BlindTarget : AntAIState
    {
        public GameObject owner;

        //Reset states function call
        
        public override void Enter()
        {
            base.Enter();
            owner.GetComponent<Blinder>().StartCoroutine("FlashPlayer");
            //owner.GetComponent<Blinder>().ResetStates();


        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            
            
            
        }

        
    }
}
