﻿using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace RileyMcGowan
{
    public class ReturnToPortal : AntAIState
    {
        //Public Vars
        
        //Private Vars
        private GameObject owner;
        private bool isFinished;
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            isFinished = false;
            owner = aGameObject;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (isFinished == true)
            {
                Finish();
            }
        }
    }
}