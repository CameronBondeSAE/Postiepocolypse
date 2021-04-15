using System.Collections.Generic;
using System.Linq;
using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class PickTarget : AntAIState
    {
        public GameObject owner;

        private List<GameObject>[] targets;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
        }
        
        public override void Enter()
        {
            
            base.Enter();
            Debug.Log("Pick Target");
           //TODO:FINISH THIS
           //owner.GetComponent<FOV>().listOfTargets

                //Send the target to the parent
          //  owner.GetComponent<Blinder>().target =;

            Finish();
        }

    }
}