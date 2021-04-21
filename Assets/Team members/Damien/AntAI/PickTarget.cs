using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class PickTarget : AntAIState
    {
        public GameObject owner;

        public FOV fieldOfView;

        public float targetViewRadius = 30f;


        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            fieldOfView = owner.GetComponent<FOV>();
        }

        public override void Enter()
        {
            base.Enter();
            //Debug.Log("Pick Target");
            owner.GetComponent<FOV>().targets = LayerMask.GetMask("Player");
            owner.GetComponent<FOV>().viewRadius = targetViewRadius;


            //Sends the target to the parent if the FOV has targets to send
            if (fieldOfView.listOfTargets.Count > 0)
            {
                owner.GetComponent<Blinder>().target = fieldOfView.listOfTargets[0];
            }
            
           // Debug.DrawLine(owner.transform.position, owner.GetComponent<Blinder>().target.transform.position, Color.red);

            
            
            Finish();
        }
    }
}