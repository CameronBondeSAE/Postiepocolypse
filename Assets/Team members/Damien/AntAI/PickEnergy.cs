using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Damien
{
    public class PickEnergy : AntAIState
    {
        public GameObject owner;

        public FOV fieldOfView;

        private int energyViewRadius = 1;
        private int maxViewRadius = 100;

        private GameObject currTarget;

        private NavMeshAgent _navMeshAgent;


        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            owner = aGameObject;
            fieldOfView = owner.GetComponent<FOV>();
            _navMeshAgent = owner.GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            //Debug.Log("Pick Energy");
            fieldOfView.targets = LayerMask.GetMask("Item");
            fieldOfView.viewRadius = energyViewRadius;


           
           
           if (fieldOfView.listOfTargets.Count == 0 && energyViewRadius <= maxViewRadius)
           {
               energyViewRadius++;
           }
           
           //Sends the target to the parent if the FOV has targets to send
           if (fieldOfView.listOfTargets.Count > 0)
           {
               for (int i = 0; i < fieldOfView.listOfTargets.Count; i++)
               {
                   if (currTarget == null && fieldOfView.listOfTargets[i].layer == LayerMask.NameToLayer("Item"))
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