using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class PickTarget : AntAIState
    {
        public GameObject owner;

        public FOV fieldOfView;

        public int targetViewRadius = 30;

        private GameObject currTarget;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            fieldOfView = owner.GetComponent<FOV>();
        }

        public override void Enter()
        {
            base.Enter();
            AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
            //Debug.Log("Pick Target");
            fieldOfView.targets = LayerMask.GetMask("Player");
            fieldOfView.viewRadius = targetViewRadius;


            //Sends the target to the parent if the FOV has targets to send
            if (fieldOfView.listOfTargets.Count > 0)
            {
                for (int i = 0; i < fieldOfView.listOfTargets.Count; i++)
                {
                    if (currTarget == null && fieldOfView.listOfTargets[i].layer == LayerMask.NameToLayer("Player"))
                    {
                        currTarget = fieldOfView.listOfTargets[i];
                        owner.GetComponent<Blinder>().target = currTarget;
                        owner.GetComponent<Blinder>().PlayScream();
                        currTarget = null;
                        
                        
                    }
                }
            }

            // Debug.DrawLine(owner.transform.position, owner.GetComponent<Blinder>().target.transform.position, Color.red);

            Finish();
        }
    }
}