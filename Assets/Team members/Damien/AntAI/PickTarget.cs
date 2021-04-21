using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class PickTarget : AntAIState
    {
        public GameObject owner;

        public FOV fieldOfView;


        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            fieldOfView = owner.GetComponentInParent<FOV>();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Pick Target");


            //Sends the target to the parent if the FOV has targets to send
            if (fieldOfView.listOfTargets.Count > 0)
            {
                owner.GetComponentInParent<Blinder>().target = fieldOfView.listOfTargets[0];
            }
            
            Debug.DrawLine(owner.transform.position, owner.GetComponent<Blinder>().target.transform.position, Color.red);

            

            Finish();
        }
    }
}