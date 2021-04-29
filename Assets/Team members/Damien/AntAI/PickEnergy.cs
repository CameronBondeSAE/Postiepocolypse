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
            //Debug.Log("Pick Energy");
            owner.GetComponentInParent<FOV>().targets = LayerMask.GetMask("Energy");
            owner.GetComponentInParent<FOV>().viewRadius = energyViewRadius;


            //Sends the target to the parent if the FOV has targets to send
            if (fieldOfView.listOfTargets.Count > 0)
            {
                owner.GetComponent<Blinder>().target = fieldOfView.listOfTargets[0];
                AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("Energy Picked", antAIAgent.GetComponent<Blinder>().target != null);
                antAIAgent.worldState.EndUpdate();
                
            }

            // Debug.DrawLine(owner.transform.position, owner.GetComponent<Blinder>().target.transform.position, Color.red);


            Finish();
        }
    }
}