using Anthill.AI;
using UnityEngine;

namespace JonathonMiles
{
    public class PickTarget : AntAIState
    {
        public GameObject owner;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log(("Picking Targets"));
            WaterTarget[] TargetList = FindObjectsOfType<WaterTarget>();
            //Picks a random available target
            WaterTarget currentTarget = TargetList[Random.Range(0, TargetList.Length)];
            //Tells NavMain which target was selected
            owner.GetComponent<NavMain>().currentTarget = currentTarget;
            Finish();
        }
    }
}

