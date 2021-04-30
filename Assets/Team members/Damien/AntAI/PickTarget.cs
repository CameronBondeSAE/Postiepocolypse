using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class PickTarget : AntAIState
    {
        public GameObject owner;

        public FOV fieldOfView;

        public int targetViewRadius = 30;


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
            owner.GetComponentInParent<FOV>().targets = LayerMask.GetMask("Player");
            owner.GetComponentInParent<FOV>().viewRadius = targetViewRadius;


            //Sends the target to the parent if the FOV has targets to send
            if (fieldOfView.listOfTargets.Count > 0)
            {
                owner.GetComponentInParent<Blinder>().target = fieldOfView.listOfTargets[0];
                AntAIAgent antAIAgent = owner.GetComponent<AntAIAgent>();
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                // antAIAgent.worldState.Set("Target Chosen", antAIAgent.GetComponent<Blinder>().target != null);
                antAIAgent.worldState.Set("Target Chosen", true);
                antAIAgent.worldState.EndUpdate();
            }

            // Debug.DrawLine(owner.transform.position, owner.GetComponent<Blinder>().target.transform.position, Color.red);

            Finish();
        }
    }
}