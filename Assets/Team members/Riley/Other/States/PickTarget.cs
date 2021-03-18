using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace RileyMcGowan
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
            Debug.Log("Pick Target");
            //Store all possible targets
            FakeTarget[] targetArray = FindObjectsOfType<FakeTarget>();
            
            //Set the target
            FakeTarget currentTarget = targetArray[Random.Range(0, targetArray.Length)];
            
            //Send the target to the parent
            owner.GetComponent<Monster_Main>().currentTarget = currentTarget;
            Finish();
        }
    }
}