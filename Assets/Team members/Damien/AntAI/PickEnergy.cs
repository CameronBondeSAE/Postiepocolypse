using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class PickEnergy : AntAIState
    {
        public GameObject owner;

        public FOV fieldOfView;

        private float energyViewRadius = 100f;
        
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
            Debug.Log("Pick Energy");
            fieldOfView.targets = LayerMask.GetMask("Energy");
            fieldOfView.viewRadius = energyViewRadius;


            //Sends the target to the parent if the FOV has targets to send
           //if (fieldOfView.listOfTargets.Count > 0)
           //{
           //    owner.GetComponent<Blinder>().energyTarget = fieldOfView.listOfTargets[0];
           //    AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
           //}
           if (fieldOfView.listOfTargets.Count > 0)
           {
               for (int i = 0; i < fieldOfView.listOfTargets.Count; i++)
               {
                   if (currTarget == null && fieldOfView.listOfTargets[i].layer == LayerMask.NameToLayer("Energy"))
                   {
                       currTarget = fieldOfView.listOfTargets[i];
                       owner.GetComponent<Blinder>().energyTarget = currTarget;
                       currTarget = null;
                   }
               }
           }


            Finish();
        }
    }
}