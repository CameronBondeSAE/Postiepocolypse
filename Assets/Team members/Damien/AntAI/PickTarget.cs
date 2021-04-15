using System.Runtime.CompilerServices;
using Anthill.AI;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

namespace Damien
{
    public class PickTarget : AntAIState
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
            Debug.Log("Pick Target");
            
            
            
            //Send the target to the parent
          //  owner.GetComponent<Blinder>().target =;

            Finish();
        }

    }
}