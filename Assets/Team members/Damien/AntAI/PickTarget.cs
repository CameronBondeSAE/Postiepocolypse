using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class PickTarget : AntAIState
    {
        public GameObject owner;

        public FOV fieldOfView;

        public List<GameObject> potentialTargets = new List<GameObject>();

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Pick Target");
            if (potentialTargets != null)
            {
                foreach (GameObject target in fieldOfView.listOfTargets)
                {
                    potentialTargets.Add(target.gameObject);
                }


                //Sends the target to the parent

                owner.GetComponentInParent<Blinder>().target = potentialTargets[0];
            }

            Finish();
        }
    }
}