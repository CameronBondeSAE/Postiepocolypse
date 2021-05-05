using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class PickEnergy : AntAIState
    {
        public GameObject owner;

        public FOV fieldOfView;

        public float energyViewRadius = 80f;


        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            fieldOfView = owner.GetComponent<FOV>();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Pick Energy");
            fieldOfView.targets = LayerMask.GetMask("Energy");
            fieldOfView.viewRadius = energyViewRadius;


            //Sends the target to the parent if the FOV has targets to send
            if (fieldOfView.listOfTargets.Count > 0)
            {
                owner.GetComponent<Blinder>().energyTarget = fieldOfView.listOfTargets[0];
                AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
            }


            Finish();
        }
    }
}